from flask import Flask, request, jsonify
from transformers import FlaxAutoModelForSeq2SeqLM
from transformers import AutoTokenizer
import recipe_generator as ai_recipes

MODEL_NAME_OR_PATH = "flax-community/t5-recipe-generation"
tokenizer = AutoTokenizer.from_pretrained(MODEL_NAME_OR_PATH, use_fast=True)
model = FlaxAutoModelForSeq2SeqLM.from_pretrained(MODEL_NAME_OR_PATH)

app = Flask(__name__)


@app.route('/register_user', methods=['POST']) # recieves user, sends back json with all ingridients
def register_user():
    request_data = request.get_json()
    user_options = db_register_user(request_data)
    return_data = get_ingredients(user_options)
    return jsonify()


@app.route('/add_ingredient', methods=['POST']) # recieves single ingridient, sends back json with all recipes
def generate_recipe_list():
    # todo: pass ingridients as one string seperated by commas:
    # ai_recipe = ai_recipes.generate_ai_recipe(model,tokenizer, ingridients)
    return jsonify("recipe list generated")


def analyze_user_info(user_info):
    return {'username', 'password', 'email', 'kosher', 'no_meat', 'no_nuts', 'no_dairy', 'no_eggs', 'no_soy', 'no_gluten'}


def db_register_user(user_info):
    user_options = analyze_user_info(user_info)
    add_user_to_db(user_options)
    return user_options


def get_ingredients(user_options):
    return "user registered"




if __name__ == '__main__':
      app.run(host='0.0.0.0', port=8080)
