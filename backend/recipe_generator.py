prefix = "items: "

generation_kwargs = {
    "max_length": 512,
    "min_length": 64,
    "no_repeat_ngram_size": 3,
    "do_sample": True,
    "top_k": 60,
    "top_p": 0.95
}

tokens_map = {
    "<sep>": "--",
    "<section>": "\n"
}

def skip_special_tokens(text, tokenizer):
    for token in tokenizer.all_special_tokens:
        text = text.replace(token, "")
    return text


def target_postprocessing(texts, tokenizer):
    if not isinstance(texts, list):
        texts = [texts]
    new_texts = []
    for text in texts:
        text = skip_special_tokens(text, tokenizer)
        for k, v in tokens_map.items():
            text = text.replace(k, v)
        new_texts.append(text)
    return new_texts


def generation_function(model, tokenizer, texts):
    _inputs = texts if isinstance(texts, list) else [texts]
    inputs = [prefix + inp for inp in _inputs]
    inputs = tokenizer(inputs, max_length=256, padding="max_length",
                       truncation=True, return_tensors="jax")
    input_ids = inputs.input_ids
    attention_mask = inputs.attention_mask

    output_ids = model.generate(input_ids=input_ids, attention_mask=attention_mask,
                                **generation_kwargs)
    generated = output_ids.sequences
    generated_recipe = target_postprocessing(
        tokenizer.batch_decode(generated, skip_special_tokens=False),
        tokenizer)
    return generated_recipe


def generate_ai_recipe(model, tokenizer, items):
    generated = generation_function(model, tokenizer, items)
    recipe = {}
    for text in generated:
        sections = text.split("\n")
        for section in sections:
            section = section.strip()
            if section.startswith("title:"):
                section = section.replace("title: ", "")
                recipe["title"] = section
                headline = "TITLE"
            elif section.startswith("ingredients:"):
                section = section.replace("ingredients: ", "")
                recipe["ingredients"] = section
                headline = "INGREDIENTS"
            elif section.startswith("directions:"):
                section = section.replace("directions: ", "")
                recipe["directions"] = section.replace('--', '\n')
                headline = "DIRECTIONS"

            if headline == "TITLE":
                print(f"[{headline}]: {section.strip().capitalize()}")
            else:
                section_info = [f"  - {i + 1}: {info.strip().capitalize()}" for i, info in
                                enumerate(section.split("--"))]
                print(f"[{headline}]:")
                print("\n".join(section_info))

        print("-" * 130)
        return recipe
