from flask import Flask, request, Response
import json
import appService

app = Flask(__name__)

@app.route('/')
def fetchUserData():
    username = request.args.get('username')
    num_of_posts = request.args.get('postNum')
    if (username is None or username == "" or num_of_posts is None or num_of_posts == ""):
        return Response("Invalid request", status=404, mimetype='application/json')

    account_info_json = appService.get_account_info_json(username, int(num_of_posts))
    return Response(account_info_json, status=200, mimetype='application/json')

@app.route('/getTopHashtagPosts')
def fetchUserData():
    hashtagId = request.args.get('hashtagId')
    if (hashtagId is None or hashtagId == ""):
        return Response("Invalid request", status=404, mimetype='application/json')

    return Response(hashtagId, status=200, mimetype='application/json')


if __name__ == "__main__":
    app.run(host="0.0.0.0", debug=True)