import appService

username = "simplemove17" #xxmarlise simplemove17
account_info_json = appService.get_account_info_json(username, 2)

print(account_info_json)