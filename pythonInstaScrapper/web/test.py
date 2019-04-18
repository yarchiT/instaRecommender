import appService

username = "simplemove17" #xxmarlise simplemove17
#account_info_json = appService.get_account_info_json(username, 2)
topHashtagPostsJson = appService.get_top_hashtag_posts_json("ocean")
topLocationPostsJson = appService.get_top_location_posts_json("219427072")
print(topHashtagPostsJson)