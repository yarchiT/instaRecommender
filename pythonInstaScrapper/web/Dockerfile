FROM python:alpine3.7

RUN apk update \
  && apk add \
    build-base \
    libpq

COPY . /app
WORKDIR /app
RUN pip install -r requirements.txt
EXPOSE 5000