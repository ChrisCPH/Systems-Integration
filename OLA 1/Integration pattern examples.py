import requests

# Pipes and filters example
def filter1(data):
    return [x.upper() for x in data]

def filter2(data):
    return [x + '!' for x in data]

def filter3(data):
    return [x[::-1] for x in data]

def pipe(data, *filters):
    for filter_func in filters:
        data = filter_func(data)
    return data

data = ["hello", "world", "pipes", "and", "filters"]
result = pipe(data, filter1, filter2, filter3)
print(result)

# Aggregator pattern example
def aggregate_data():
    user_response = requests.get('https://jsonplaceholder.typicode.com/users/1')
    posts_response = requests.get('https://jsonplaceholder.typicode.com/posts?userId=1')
    
    user_data = user_response.json()
    posts_data = posts_response.json()
    
    aggregated_data = {
        "user": user_data,
        "posts": posts_data
    }
    
    return aggregated_data

result = aggregate_data()
print(result)

# Content Enricher pattern example
def enrich_data(user_data):
    response = requests.get(f'https://jsonplaceholder.typicode.com/users/{user_data["id"]}')
    details = response.json()
    enriched_data = {**user_data, **details}
    return enriched_data

user_data = {"id": 1, "name": "Alice"}
enriched_data = enrich_data(user_data)
print(enriched_data)
