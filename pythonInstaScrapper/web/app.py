from flask import Flask, request
import json
import appService

app = Flask(__name__)

@app.route('/')
def hello():
    username = request.args.get('username')
    account_info_json = appService.get_account_info_json(username)

    return account_info_json

if __name__ == "__main__":
    app.run(host="0.0.0.0", debug=True)