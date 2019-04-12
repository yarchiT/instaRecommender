from instagram.agents import WebAgent, WebAgentAccount
from instagram.entities import Account, Media, Location, Tag
from accountInfoEntity import AccountInfoEntity, PostEntity, LocationEntity
import json
import re
import jsonpickle


def get_account_info_json(username):
    accountInfo =  AccountInfoEntity(username)
    agent = WebAgent()
    account = WebAgentAccount(username)
    agent.update(account)

    #accountInfo.bio = account.bio
    posts = agent.get_media(account, count=6)[0]

    for post in posts:
        postEntity = PostEntity()
        if not post.location is None:
            postEntity.location = LocationEntity(post.location.id)
            agent.update(post.location)
        
        if not post.caption is None:
            postEntity.hash_tags.append(re.findall(r"#(\w+)", post.caption))
            postEntity.caption = post.caption

        if not post.is_video:
            postEntity.photo_url = post.display_url
        
        accountInfo.posts.append(postEntity)
    
    accountInfoJson = jsonpickle.encode(accountInfo)
    return accountInfoJson

