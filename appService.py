from instagram.agents import WebAgent, WebAgentAccount
from instagram.entities import Account, Media, Location, Tag
from accountInfoEntity import AccountInfoEntity, PostEntity, LocationEntity
import json
import re
import jsonpickle


def get_account_info_json(username):
    agent = None
    accountInfo = None
    posts = []
    try:
        accountInfo =  AccountInfoEntity(username)
        agent = WebAgent()
        account = WebAgentAccount(username)
        agent.update(account)

        accountInfo.bio = account.biography
        accountInfo.total_media_count = account.media_count
        posts = agent.get_media(account, count=account.media_count)[0]
    except:
        print("error while getting account info")
   
    if agent is None or accountInfo is None:
        return "Coudn't get account Info"

    for post in posts:
        try:
            postEntity = PostEntity()
            if not post.location is None:
                agent.update(post.location)
                locationEntity = LocationEntity(post.location.id)
                locationEntity.name = post.location.name
                if post.location.directory is not None:
                    locationEntity.city = post.location.directory.get("city").get("name")
                    locationEntity.country = post.location.directory.get("country").get("name")
                postEntity.location = locationEntity
                
            if not post.caption is None:
                postEntity.hash_tags = re.findall(r"#(\w+)", post.caption)
                postEntity.caption = post.caption

            if not post.is_video:
                postEntity.photo_url = post.display_url
            
            accountInfo.posts.append(postEntity)
            accountInfo.parsed_post_count+=1
        except:
            print("Error while getting post data")
            continue
       
    accountInfoJson = jsonpickle.encode(accountInfo, unpicklable=False)
    return accountInfoJson

