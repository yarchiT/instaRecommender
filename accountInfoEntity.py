class AccountInfoEntity():

    def __init__(self, username):
        self.username = username
        self.bio = ""
        self.posts = []
        self.total_media_count = 0
        self.parsed_post_count = 0

class PostEntity():
    def __init__(self):
        self.location = None
        self.hash_tags = []
        self.photo_url = ""
        self.caption = ""

class LocationEntity():
    def __init__(self, id):
        self.id = id
        self.name = ""
        self.city = ""
        self.country = ""
        