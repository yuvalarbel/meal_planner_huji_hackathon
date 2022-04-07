CREATE TABLE users (
  id INTEGER PRIMARY KEY AUTOINCREMENT,
  username TEXT NOT NULL,
  password TEXT NOT NULL,
  email TEXT NOT NULL,
  created_at DATETIME DEFAULT CURRENT_TIMESTAMP
);

CREATE TABLE user_settings (
  user_id INTEGER NOT NULL,
  no_meat INTEGER DEFAULT 0,
  no_nuts INTEGER DEFAULT 0,
  no_dairy INTEGER DEFAULT 0,
  no_eggs INTEGER DEFAULT 0,
  no_soy INTEGER DEFAULT 0,
  no_gluten INTEGER DEFAULT 0,
  FOREIGN KEY (user_id) REFERENCES users(id)
);

CREATE TABLE recipes (
  id INTEGER PRIMARY KEY,
  title TEXT NOT NULL,
  link TEXT NOT NULL,
  image_path
);

CREATE TABLE ingredients (
  id INTEGER PRIMARY KEY AUTOINCREMENT,
  name TEXT NOT NULL,
  contains_meat INTEGER DEFAULT 0,
  contains_nuts INTEGER DEFAULT 0,
  contains_dairy INTEGER DEFAULT 0,
  contains_eggs INTEGER DEFAULT 0,
  contains_soy INTEGER DEFAULT 0,
  contains_gluten INTEGER DEFAULT 0
);

CREATE TABLE recipe_ingredients (
  recipe_id INTEGER NOT NULL,
  ingredient_id INTEGER NOT NULL,
  amount TEXT NOT NULL,
  unit TEXT NOT NULL,
  FOREIGN KEY (recipe_id) REFERENCES recipes(id),
  FOREIGN KEY (ingredient_id) REFERENCES ingredients(id)
);

CREATE TABLE recipe_directions (
  recipe_id INTEGER NOT NULL,
  step_number INTEGER NOT NULL,
  step TEXT NOT NULL,
  FOREIGN KEY (recipe_id) REFERENCES recipes(id)
);
