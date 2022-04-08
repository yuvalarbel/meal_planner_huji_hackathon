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

user_id = dbt.get_max_user_id()
ingredients = []
global_user_options = None


@app.route('/register_user', methods=['POST']) # recieves user, sends back json with all ingridients
def register_user():
    dbt.reset_ingredients()

    request_data = json.loads(request.get_json())
    user_options = utils.analyze_user_info(request_data)

    updated_user_options = dbt.add_user_to_db(user_options)
    return_data = dbt.get_ingredients(updated_user_options)

    return jsonify(return_data)


@app.route('/add_ingredient', methods=['POST'])  # recieves single ingredient, sends back json with all recipes
def add_ingredient():
    request_data = json.loads(request.get_json())

    dbt.add_ingredient_to_db(request_data['Name'])

    free_count, paid_count, min_price = dbt.get_recipe_numbers()
    return_data = {
        'free_recipy_count': free_count,
        'paid_recipy_count': paid_count,
        'current_min_price': min_price
    }

    return jsonify(return_data)


@app.route('/generate_recipes', methods=['POST'])
def generate_recipes():
    request_data = request.get_json()
    ai_recipe = ai_recipes.generate_ai_recipe(model, tokenizer, ingredients)
    queried_recipes = dbt.get_recipes(user_id, ingredients)
    return jsonify("recipe list generated")


if __name__ == '__main__':
      app.run(host='0.0.0.0', port=8080)
