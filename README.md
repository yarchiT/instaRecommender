# instagramRecommender
[![MIT license](https://img.shields.io/badge/license-MIT-blue.svg)](https://github.com/yarchiT/instaRecommender)
[![built with Python3](https://img.shields.io/badge/built%20with-Python3-red.svg)](
https://www.python.org/)

### Description
This is a simple instagram recommender system, that proposes posts based on your account. In scraps data from web instagram using this library (https://github.com/OlegYurchik/pyInstagram#basic-installation), then parses the data from posts (hashtags, captions, bio ..) and stores it in the relational database.
I'm using content-based + knowledge-based recommender approaches (More info you can find in the book "Recommender Systems: An Introduction by Dietmar Jannach and Markus Zanker").  

User Guide
=================


## Getting Started

## Basic Installation

For basic installation you should have docker installed on your system.
You need to build and run the docker-compose file

```bash
1. cd instaRecommender
2. docker-compose up --build
    or if you want to run containers on background mode, add parameter -d
    docler-compose up --build -d
``` 

## Development details

**Web app:**
I have three main processes
1. Nginx: Webserver listens on port 80 for incoming HTTP requests from the internet. It will handle static files (html/css/js) by itself, but in case request need to be dynamically generated, it will then be passed to the applciation - Gunicorn
2. Gunicorn: Listens on another port for HTTP requests from nginx. Gunicorn is configured with my python web app.
3. Database



