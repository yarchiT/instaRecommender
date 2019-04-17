class AccountInfoEntity():

    def __init__(self, username):
        self.Username = username
        self.Bio = ""
        self.Posts = []
        self.TotalMediaCount = 0
        self.ParsedPostCount = 0

class PostEntity():
    def __init__(self):
        self.OwnerUsername = ""
        self.HashTags = []
        self.PhotoUrl = ""
        self.Caption = ""
        self.LocationId = ""
        self.LocationName = ""
        self.LocationCountry = ""
        self.AccessibilityCaption = ""

        