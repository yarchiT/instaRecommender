class AccountInfoEntity():

    def __init__(self, username):
        self.username = username
        self.locations = []
        self.hash_tags = []
        self.photo_urls = []
        self.captions = []
        self.bio = ""