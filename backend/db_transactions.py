#!%PYTHON_HOME%\python.exe
# coding: utf-8

import sqlite3
import json
import queries as q
import utils


INGREDIENTS_TAGS = {'no_meat': 'contains_meat',
                    'no_nuts': 'contains_nuts',
                    'no_dairy': 'contains_dairy',
                    'no_soy': 'contains_soy',
                    'no_gluten': 'contains_gluten'}
PRICE_TRESHOLD = 50
RECIPE_NAMES = ['title', 'ingredients', 'directions', 'price', 'missing_ingredients']

conn = sqlite3.connect('data.db', check_same_thread=False)



def add_user_to_db(user_options):
    cur = conn.execute(q.MAX_USER_QUERY)
    lines = cur.fetchall()
    user_id = lines[0][0] + 1 if lines else 1
    user_options['id'] = user_id
    conn.execute(f"INSERT INTO users (id, username, password, email) "
                 f"VALUES ({user_options['id']}, "
                        f"'{user_options['username']}', "
                        f"'{user_options['password']}', "
                        f"'{user_options['email']}');")
    conn.execute(f"INSERT INTO user_settings (user_id, kosher, no_meat, no_nuts, no_dairy, no_soy, no_gluten)"
                 f"VALUES ({user_options['id']},"
                         f"{user_options['kosher']}, "
                         f"{user_options['no_meat']}, "
                         f"{user_options['no_nuts']}, "
                         f"{user_options['no_dairy']}, "
                         f"{user_options['no_soy']}, "
                         f"{user_options['no_gluten']});")
    conn.commit()
    return user_options


def get_ingredients(user_options):
    query = f"SELECT name, price, order_num FROM ingredients WHERE 1=1"
    for user_tag, ingredient_tag in INGREDIENTS_TAGS.items():
        if user_options[user_tag]:
            query += f"\nAND {ingredient_tag} IS NULL"
    query += "\nORDER BY order_num ASC;"
    cur = conn.execute(query)
    return [{'Name': line[0],
             'Image_path': "",
             'Price': line[1]} for line in cur.fetchall()]


def get_user_options():
    cur = conn.execute(q.USERS_DATA_QUERY)
    return utils.list_to_user_dict(cur.fetchall()[0])


def get_recipe_numbers():
    user_options = get_user_options()
    kosher = "AND kosher = 1" if user_options['kosher'] else ""
    free_query = q.FREE_RECIPES_QUERY.format(kosher=kosher)
    cur = conn.execute(free_query)
    lines = cur.fetchall()
    free_count = lines[0][0] if lines else 0

    constraints_str = ""
    for user_tag, ingredient_tag in INGREDIENTS_TAGS.items():
        if user_options[user_tag]:
            constraints_str += f"\nAND {ingredient_tag} IS NULL"

    paid_query = q.PAID_RECIPES_QUERY.format(kosher=kosher,
                                             constraints=constraints_str, price=PRICE_TRESHOLD)
    cur = conn.execute(paid_query)
    lines = cur.fetchall()
    if not lines:
        paid_count, min_price = 0, "$$$"
    else:
        paid_count = len(lines)
        min_price = lines[0][1]

    return free_count, paid_count, min_price


def reset_ingredients():
    conn.execute(q.RESET_INGREDIENTS_QUERY)
    conn.commit()


def add_ingredient_to_db(name):
    conn.execute(f"INSERT INTO cur_ingredients (name) VALUES ('{name}');")
    conn.commit()


def get_cur_ingredients():
    cur = conn.execute(q.CUR_INGREDIENTS_QUERY)
    return [line[0] for line in cur.fetchall()]


def get_recipes():
    cur = conn.execute(q.GENERATE_RECIPES_QUERY)
    return_list = [dict(zip(RECIPE_NAMES, line)) for line in cur.fetchall()]
    for recipe in return_list:
        recipe['is_ai'] = False
    return return_list
