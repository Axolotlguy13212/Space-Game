extends Node

@export var score_text_path: NodePath
@export var high_score_text_path: NodePath

var score_text: Label
var high_score_text: Label

var score_script: Node = null
var score: int = 0
var high_score: int = 0

func _ready() -> void:
	score_text = get_node(score_text_path)
	high_score_text = get_node(high_score_text_path)
	score = 0

func _process(delta: float) -> void:
	if score_script != null:
		score_script.current_score = score
		score_script.high_score = high_score

	if score_text:
		score_text.text = "Score: %d" % score

	if high_score_text:
		high_score_text.text = "High Score: %d" % high_score
