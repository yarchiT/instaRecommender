class AccountInfoEntity():

    def __init__(self, username):
        self.username = username
        self.bio = ""
        self.posts = []

class PostEntity():
    def __init__(self):
        self.location = None
        self.hash_tags = []
        self.photo_url = ""
        self.caption = ""

class LocationEntity():
    def __init__(self, id):
        self.name = ""
        self.country = ""