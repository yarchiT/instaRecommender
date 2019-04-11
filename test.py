from accountInfoEntity import AccountInfoEntity
import appService

username = "xxmarlise"
account_info_json = appService.get_account_info_json(username)

print(account_info_json)