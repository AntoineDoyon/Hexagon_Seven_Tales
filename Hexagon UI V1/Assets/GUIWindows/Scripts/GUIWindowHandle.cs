﻿using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.Events;

public class GUIWindowHandle : MonoBehaviour {

	[SerializeField] private RectTransform parentWindow = null;
	[SerializeField] private bool isLocked = false;
	public float minWidth = 50;
	public float minHeight = 50;
	[SerializeField] private Texture2D cursor = null;
	[SerializeField] private Axis axis = Axis.Horizontal;
	[SerializeField] private UnityEvent onWindowPulled = null;
	Direction direction;
	private bool isGrabbed = false;


	private Vector2 initialMousePos;
	private Vector2 initialSize;
	private Vector2 initialPivot;

	void Start ()
	{
		// find what direction we're pulling with this handle
		switch (axis) {

		case Axis.Horizontal:
			if (transform.position.x > parentWindow.position.x) {
				direction = Direction.Right;
			} else {
				direction = Direction.Left;
			}
			break;

		case Axis.Vertical:
			if (transform.position.y > parentWindow.position.y) {
				direction = Direction.Up;
			} else {
				direction = Direction.Down;
			}
			break;

		case Axis.Diagonal:
			if (transform.position.y > parentWindow.position.y) {
				if (transform.position.x > parentWindow.position.x) {
					direction = Direction.UpRight;
				} else {
					direction = Direction.UpLeft;
				}
			} else {
				if (transform.position.x > parentWindow.position.x) {
					direction = Direction.DownRight;
				} else {
					direction = Direction.DownLeft;
				}
			}
			break;
		}
	}

	void Update ()
	{
		if (!isGrabbed)
			return;

		if (Input.GetMouseButtonUp (0)) {
			isGrabbed = false;
			parentWindow.SetPivot(initialPivot);
			if (onWindowPulled != null) {
				onWindowPulled.Invoke ();
			}
			return;
		}

		Vector2 scaleOffset = (Vector2.one - (Vector2)transform.lossyScale) + Vector2.one;
		Vector2 mouseDelta = Vector2.Scale ((Vector2)Input.mousePosition - initialMousePos, scaleOffset);
		Vector2 size = initialSize;

		switch (direction) {
			case Direction.Up:
			size += new Vector2 (0, mouseDelta.y);
			break;
			case Direction.Down:
			size -= new Vector2 (0, mouseDelta.y);
			break;
			case Direction.Left:
			size -= new Vector2 (mouseDelta.x, 0);
			break;
			case Direction.Right:
			size += new Vector2 (mouseDelta.x, 0);
			break;
			case Direction.UpRight:
			size += new Vector2 (mouseDelta.x, mouseDelta.y);
			break;
			case Direction.UpLeft:
			size += new Vector2 (-mouseDelta.x, mouseDelta.y);
			break;
			case Direction.DownRight:
			size += new Vector2 (mouseDelta.x, -mouseDelta.y);
			break;
			case Direction.DownLeft:
			size += new Vector2 (-mouseDelta.x, -mouseDelta.y);
			break;
		}

		// Keep Window within minimum size
		if (size.x < minWidth || size.y < minHeight) {
			Vector2 newsize = size;
			if (size.x < minWidth) {
				newsize.x = minWidth;
			}
			if (size.y < minHeight) {
				newsize.y = minHeight;
			}
			parentWindow.sizeDelta = newsize;
			return;
		}

		// set position & size
		parentWindow.sizeDelta = size;
	}

	public void SetIsLocked (bool input) {
		isLocked = input;
	}

	public void SetIsGrabbed ()
	{
    	if (isLocked) return;
		isGrabbed = true;

		initialMousePos = Input.mousePosition;
		initialSize = parentWindow.sizeDelta;
		initialPivot = parentWindow.pivot;

		// Set Pivot to correct value based on direction so we don't need to offset movement
		switch (direction) {
		case Direction.Up:
			parentWindow.SetPivot(new Vector2(0.5f,0));
			break;
		case Direction.Down:
			parentWindow.SetPivot(new Vector2(0.5f,1));
			break;
		case Direction.Left:
			parentWindow.SetPivot(new Vector2(1,0.5f));
			break;
		case Direction.Right:
			parentWindow.SetPivot(new Vector2(0,0.5f));
			break;
		case Direction.UpRight:
			parentWindow.SetPivot(new Vector2(0,0));
			break;
		case Direction.UpLeft:
			parentWindow.SetPivot(new Vector2(1,0));
			break;
		case Direction.DownRight:
			parentWindow.SetPivot(new Vector2(0,1));
			break;
		case Direction.DownLeft:
			parentWindow.SetPivot(new Vector2(1,1));
			break;
		}
	}

	public void ShowCursor ()
	{
		if (!isLocked && cursor != null) {
			Cursor.SetCursor (cursor, new Vector2(16, 16), CursorMode.Auto);
		}
    }

	public void ResetCursor ()
	{
		if (cursor != null) {
			Cursor.SetCursor (null, Vector2.zero, CursorMode.Auto);
		}
	}

	private enum Axis {
		Horizontal,
		Vertical,
		Diagonal
	}

	private enum Direction {
		Up,
		Down,
		Left,
		Right,
		UpLeft,
		UpRight,
		DownLeft,
		DownRight
	}
}