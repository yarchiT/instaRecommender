from instagram.agents import WebAgent, WebAgentAccount
from instagram.entities import Account, Media, Location, Tag
from models import AccountInfoEntity, PostEntity
import json
import re
import jsonpickle


def get_account_info_json(username, num_of_posts):
    agent = None
    accountInfo = None
    posts = []
    try:
        accountInfo =  AccountInfoEntity(username)
        agent = WebAgent()
        account = WebAgentAccount(username)
        agent.update(account)

        accountInfo.Bio = account.biography
        accountInfo.TotalMediaCount = account.media_count
        posts = agent.get_media(account, count=num_of_posts)[0]  # account.media_count
    except:
        print("error while getting account info")
   
    if agent is None or accountInfo is None:
        return "Coudn't get account Info"

    for post in posts:
        try:
            postEntity = PostEntity()
            if not post.location is None:
                agent.update(post.location)
                postEntity.LocationId = post.location.id
                postEntity.LocationName = post.location.name
                if post.location.directory is not None:
                    postEntity.LocationCountry = post.location.directory.get("country").get("name")

            if not post.accessibility_caption is None:
                postEntity.AccessibilityCaption = post.accessibility_caption

              
            if not post.caption is None:
                postEntity.HashTags = re.findall(r"#(\w+)", post.caption)
                postEntity.Caption = post.caption

            if not post.is_video:
                postEntity.PhotoUrl = post.display_url
            
            accountInfo.Posts.append(postEntity)
            accountInfo.ParsedPostCount+=1
        except:
            print("Error while getting post data")
            continue
       
    accountInfoJson = jsonpickle.encode(accountInfo, unpicklable=False)
    return accountInfoJson

