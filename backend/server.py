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
    return "user registered"

@app.route('/add_ingridient', methods=['POST']) # recieves single ingridient, sends back json with all recipes
def generate_recipe_list():
    # todo: pass ingridients as one string seperated by commas:
    # ai_recipe = ai_recipes.generate_ai_recipe(model,tokenizer, ingridients)
    return "recipe list generated"

if __name__ == '__main__':
      app.run(host='0.0.0.0', port=8080)
