import appService

username = "yaroshenochkaa" #xxmarlise simplemove17
#account_info_json = appService.get_account_info_json(username, 20)
# topHashtagPostsJson = appService.get_top_hashtag_posts_json("ocean")
topLocationPostsJson = appService.get_top_location_posts_json(989016049)
print(topLocationPostsJson)