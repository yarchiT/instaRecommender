from instagram.agents import WebAgent, WebAgentAccount
from instagram.entities import Account, Media, Location, Tag
from accountInfoEntity import AccountInfoEntity
import json


def get_account_info_json(username):
    accountInfo =  AccountInfoEntity(username)
    agent = WebAgent()
    account = WebAgentAccount(username)
    agent.update(account)

    posts = agent.get_media(account, count=6)[0]

    for post in posts:
        if not post.location is None:
            accountInfo.locations.append(post.location.id)
        
        if not post.caption is None:
            accountInfo.captions.append(post.caption)

        if not post.is_video:
            accountInfo.photo_urls.append(post.display_url)
    
    accountInfoJson = json.dumps(accountInfo.__dict__)
    return accountInfoJson

