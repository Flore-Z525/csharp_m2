import json
import csv

with open('hp.json', 'r', encoding='utf-8') as infile:
    data = json.load(infile)

with open('hp.csv', 'w', encoding='utf-8', newline='') as outfile:
    writer = csv.writer(outfile)

    # writer.writerow(["name", "species", "gender", "house", "yearOfBirth"])

    for character in data:
        writer.writerow([
            character.get("name", ""),
            character.get("species", ""),
            character.get("gender", ""),
            character.get("house", ""),
            character.get("yearOfBirth", "")
        ])
