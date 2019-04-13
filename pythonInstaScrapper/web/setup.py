from setuptools import setup, find_packages
from os.path import join, dirname


setup(
    name = "instagram",
    version = "1.0",
    author = "Yaroslav Tykhonchuk",
    author_email = "ytykhonchuk@gmail.com",
    url = "",
    description = "",
    long_description = open(join(dirname(__file__), "README.md")).read(),
    packages = find_packages(),
    install_requires = ["aiohttp", "pytest", "pytest-asyncio", "pytest-random-order", "requests"],
    test_suite = "tests/",
)