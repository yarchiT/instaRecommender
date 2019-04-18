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
    except Exception as e:
        print("error while getting account info")
   
    if agent is None or accountInfo is None:
        return "Coudn't get account Info"

    accountInfo.posts = _get_list_of_parsed_posts(agent, posts)
    accountInfo.parsedPostEntities = posts.count
       
    accountInfoJson = jsonpickle.encode(accountInfo, unpicklable=False)
    return accountInfoJson

def get_top_hashtag_posts_json(hashtag):
    agent = None
    parsedPosts = []
    try:
        agent = WebAgent()
        hashtag = Tag(hashtag)
        agent.update(hashtag)
        posts = agent.get_media(hashtag, count=2)[0]
        parsedPosts = _get_list_of_parsed_posts(agent, posts, True)
    except:
        print("error while getting account info")
    
    topHashtagPostsJson = jsonpickle.encode(parsedPosts, unpicklable=False)
    return topHashtagPostsJson

def get_top_location_posts_json(locationId):
    agent = None
    parsedPosts = []
    try:
        agent = WebAgent()
        location = Location(locationId)
        agent.update(location)
        posts = agent.get_media(location, count=3)[0]
        parsedPosts = _get_list_of_parsed_posts(agent, posts, True)
    except:
        print("error while getting account info")
    
    top_location_posts_json = jsonpickle.encode(parsedPosts, unpicklable=False)
    return top_location_posts_json



def _get_list_of_parsed_posts(agent, posts, needsUpdate=False):
    parsedPostEntities = []
    for post in posts:
        try:
            if (needsUpdate):
                agent.update(post)
            postEntity = PostEntity()
            postEntity.OwnerUsername = post.owner.username
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
            
            parsedPostEntities.append(postEntity)
        except:
            print("Error while getting post data")
            continue
        
    return parsedPostEntities
