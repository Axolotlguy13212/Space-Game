extends Area2D

# Exported or public variables
var movement_speed: float
var asteroid_sprite: float # Not used in the script, included for parity
var score: int = 0
var high_score: int = 0

# Reference to score script
var score_script: Node = null

func _ready() -> void:
	movement_speed = randf_range(10, 30)


func _process(delta: float) -> void:
	var velocity = Vector2.ZERO
	velocity += Vector2.LEFT

	position += velocity.normalized() * movement_speed

	delete_asteroid()

	if score_script:
		score_script.current_score = score
		score_script.high_score = high_score


func delete_asteroid() -> void:
	if position.x < -1500.0:
		queue_free()
		score += 1
