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