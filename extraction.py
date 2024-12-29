import json

with open('potter.json', 'r', encoding='utf-8') as infile:
    data = json.load(infile)

filtered_data = []
for character in data:
    filtered_character = {
        "name": character.get("name"),
        "species": character.get("species"),
        "gender": character.get("gender"),
        "house": character.get("house"),
        "yearOfBirth": character.get("yearOfBirth")
    }
    filtered_data.append(filtered_character)

with open('hp.json', 'w', encoding='utf-8') as outfile:
    json.dump(filtered_data, outfile, indent=4, ensure_ascii=False)

print("hp.json sauvegardé")