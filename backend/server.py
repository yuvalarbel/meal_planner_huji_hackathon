from flask import Flask, request, jsonify
from transformers import FlaxAutoModelForSeq2SeqLM
from transformers import AutoTokenizer
import recipe_generator as ai_recipes
import db_transactions as dbt
import utils
import json

MODEL_NAME_OR_PATH = "flax-community/t5-recipe-generation"
tokenizer = AutoTokenizer.from_pretrained(MODEL_NAME_OR_PATH, use_fast=True)
model = FlaxAutoModelForSeq2SeqLM.from_pretrained(MODEL_NAME_OR_PATH)

app = Flask(__name__)

LONG_VALUE_LIMIT = 120
LONG_VALUE_FILLER = '<Long {type} object with repr length {length}>'


def pprint_dict(dictionary, long_value_limit=LONG_VALUE_LIMIT, long_value_filler=LONG_VALUE_FILLER):
    """
    Prints a dict in a very pretty way!

    :param dictionary: your dict to print
    :type dictionary: dict
    :param long_value_limit: when a dict value exceeds this limit, it won't be printed
                             Default: 120
    :type long_value_limit: int
    :param long_value_filler: A filler to print instead of a long value, must have {type} and {length} fields!
                              Default: '<Long {type} object with repr length {length}>'
    :type long_value_filler: str
    :return: None
    """
    indent_len = max([len(str(key)) for key in dictionary.keys()]) + 2
    for key, value in dictionary.items():
        repr_value = repr(value)
        if len(repr_value) > long_value_limit:
            repr_value = long_value_filler.format(type=type(value)._name_,
                                                  length=len(repr_value))
        print('{key}:{spaces}{value}'.format(
            key=key,
            spaces=' '*(indent_len - len(str(key))),
            value=repr_value
        ))

@app.route('/register_user', methods=['POST']) # recieves user, sends back json with all ingridients
def register_user():
    dbt.reset_ingredients()

    request_data = json.loads(request.get_json())
    print("\n\nGot new user: ")
    pprint_dict(request_data)
    user_options = utils.analyze_user_info(request_data)

    updated_user_options = dbt.add_user_to_db(user_options)
    return_data = dbt.get_ingredients(updated_user_options)

    print("\n\nReturning all ingredients ordered by importance: ")
    for d in return_data[:15]:
        print("Name: ", d['Name'], "\tPrice: ", d['Price'], "NIS")


    return jsonify(return_data)


@app.route('/add_ingredient', methods=['POST'])  # recieves single ingredient, sends back json with all recipes
def add_ingredient():
    new_ingredient = request.get_json()[1:-1].lower()
    print("\n\nGot new ingredient: " + new_ingredient)
    dbt.add_ingredient_to_db(new_ingredient)

    free_count, paid_count, min_price = dbt.get_recipe_numbers()
    return_data = {
        'free_recipy_count': free_count,
        'paid_recipy_count': paid_count,
        'current_min_price': min_price
    }

    print("Current ingredients are: ", dbt.get_cur_ingredients())

    print("Returning: ")
    print("Number of free recipes: ", free_count)
    print("Number of paid recipes: ", paid_count)
    print("Current minimum price for a paid recipe: ", min_price, "NIS")

    return jsonify(return_data)


@app.route('/generate_recipes', methods=['POST'])
def generate_recipes():
    request_data = request.get_json()
    print("\n\nGenerating Artificial Intelligence Created Recipe:\n")
    ingredients = dbt.get_cur_ingredients()
    ai_recipe = ai_recipes.generate_ai_recipe(model, tokenizer, ", ".join(ingredients))
    ai_recipe['is_ai'] = True
    ai_recipe['is_free'] = True
    ai_recipe['image_path'] = ""
    ai_recipe['time'] = 30
    ai_recipe['price'] = 0
    ai_recipe['missing_ingredients'] = []
    queried_recipes = dbt.get_recipes()
    return_data = [ai_recipe] + queried_recipes
    return jsonify(return_data)


if __name__ == '__main__':
      app.run(host='0.0.0.0', port=8080)
