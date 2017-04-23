import csv
import json

with open('planets.csv') as f:
    reader = csv.DictReader(f)
    rows = list(reader)

with open('planets.json', 'w') as f:
    json.dump(rows, f)