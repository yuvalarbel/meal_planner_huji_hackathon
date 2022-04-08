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

conn = sqlite3.connect('data.db', check_same_thread=False)


def get_max_user_id():
    cur = conn.execute(q.MAX_USER_QUERY)
    if cur.rowcount == -1:
        return 0
    return cur.fetchone()[0]


def add_user_to_db(user_options):
    user_id = get_max_user_id() + 1
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
    query = f"SELECT id, name FROM ingredients WHERE 1=1"
    for user_tag, ingredient_tag in INGREDIENTS_TAGS.items():
        if user_options[user_tag]:
            query += f"\nAND {ingredient_tag} IS NULL"
    query += "ORDER BY order_num ASC;"
    cur = conn.execute(query)
    return cur.fetchall()


def get_user_options():
    cur = conn.execute(q.USERS_DATA_QUERY)
    return utils.list_to_user_dict(cur.fetchall()[0])


def get_recipes(user_id, ingredients):
    return None


def get_recipe_numbers():
    user_options = get_user_options()
    kosher = "AND kosher = 1" if user_options['kosher'] else ""
    free_query = q.FREE_RECIPES_QUERY.format(kosher=kosher)
    cur = conn.execute(free_query)
    free_count = 0 if cur.rowcount == -1 else cur.fetchone()[0]

    constraints_str = ""
    for user_tag, ingredient_tag in INGREDIENTS_TAGS.items():
        if user_options[user_tag]:
            constraints_str += f"\nAND {ingredient_tag} IS NULL"

    paid_query = q.PAID_RECIPES_QUERY.format(kosher=kosher,
                                             constraints=constraints_str, price=PRICE_TRESHOLD)
    cur = conn.execute(paid_query)
    if cur.rowcount == -1:
        paid_count, min_price = 0, "$$$"
    else:
        info = cur.fetchall()
        paid_count = len(info)
        min_price = info[0][1]

    return free_count, paid_count, min_price


def reset_ingredients():
    conn.execute(q.RESET_INGREDIENTS_QUERY)
    conn.commit()


def add_ingredient_to_db(name):
    conn.execute(f"INSERT INTO cur_ingredients (name) VALUES ('{name}');")
    conn.commit()
