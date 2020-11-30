extends Control

var translator = load("res://Translator.cs")
onready var translator_node = translator.new()

func _ready() -> void:
	print(translator_node.TranslateTextWithModel())
