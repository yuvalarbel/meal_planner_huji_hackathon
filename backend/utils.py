def analyze_user_info(user_info):
     """
     :param user_info: a dictionary containing the user's info from front end
     :return: a dictionary containing the user's info formatted for the DB
     """
     user_dict = {}
     user_dict['username'] = user_info['UserName']
     user_dict['password'] = user_info['Password']
     user_dict['email'] = user_info['Email']
     user_dict['kosher'] =  user_info['Kosher']
     user_dict['no_meat'] = user_info['Vegeterian'] or user_info['Vegan']
     user_dict['no_nuts'] = user_info['NoNuts']
     user_dict['no_dairy'] = user_info['NoMilk'] or user_info['Vegan']
     user_dict['no_soy'] = user_info['NoSoy']
     user_dict['no_gluten'] = user_info['NoGluten']
     return user_dict

def list_to_user_dict(db_list):
     user_dict = {}
     user_dict['userid'] = db_list[0]
     user_dict['username'] = db_list[1]
     user_dict['password'] = db_list[3]
     user_dict['email'] = db_list[2]
     user_dict['kosher'] =  db_list[6]
     user_dict['no_meat'] = db_list[7]
     user_dict['no_nuts'] = db_list[8]
     user_dict['no_dairy'] = db_list[9]
     user_dict['no_soy'] = db_list[10]
     user_dict['no_gluten'] = db_list[11]
     return user_dict