// 1. Постановка задачи (кратко словами описать одну фичу)
// 2. Описать, как будет происходить взаимодейтсвие с этой фичей 
// ПИСАТЬ ВСЁ, ДАЖЕ ОЧЕВИДНЫЕ ВЕЩИ, НИЧЕГО НЕ ОСТАВЛЯТЬ В ГОЛОВЕ
// 3. Логика: Расписать всё в формате причина -> следствие
// 4. Входные данные и выходные данные (переписать из пункта 4 в две отдельные колонки)
// 5. Псевдокод
// 6. Понятный нейминг (Писать так, как будто я пишу код себе через месяц)

// 		//* Вращать один объект среди множества с помощью мышки
// 		//? Нажатие ЛКМ на объект == выбор объекта,

// 		//? удержание мыши,
// 		//? сдвиг мыши вправо/влево,
// 		//? поворот выбранного объекта вместе с курсором

// 		//? ЛКМ отжата



// 		//* Логика
// 		//? Нажатие ЛКМ на объект -> выбор объекта
// 		//? Удерживание мыши + Движение курсора -> поворот выбранного объекта
// 		//? Отжатие ЛКМ -> конец

// 		//* Входные данные
// 		//? Объекты, из которых выбирать
// 		//? Выбранный объект
// 		//? Нажатие ЛКМ на объект
// 		//? Удерживание ЛКМ
// 		//? Движение курсора 
// 		//? Отжатие ЛКМ

// 		//* Выходные данные
// 		//? Выбор объекта
// 		//? Поворот выбранного объекта
// 		//? Конец

// using UnityEngine;
// using System.Collections.Generic;

// public class Logic
// {
// 	//* Входные данные
// 	List<GameObject> objects;
// 	GameObject selectedObject;
// 	bool lmbJustPressed;
// 	bool lmbIsPressed;
// 	Vector2 cursorPosition;

// 	//* Выходные данные
// 	GameObject selectedObject;
// 	Vector3 selectedObjectRotation { get => selectedObject.rotation.eulerAngles; set => selectedObject.rotation.eulerAngles = value; }
// 	public void Update()
// 	{
// 		//* Логика
// 		//? Нажатие ЛКМ на объект -> выбор объекта
// 		//? Удерживание мыши + Движение курсора -> поворот выбранного объекта
// 		//? Отжатие ЛКМ -> конец

// 		if (lmbJustPressed == true)
// 		{
// 			cursorPosition = GetMousePosition();
// 			selectedObject = FindObjectAtMousePosition(cursorPosition); //? FindObjectAtMousePosition
// 			if (selectedObject != null)
// 			{
// 				StartCoroutine("RotationRoutine");
// 			}
// 		}
// 	}

// 	private IEnumerator RotationRoutine()
// 	{
// 		while (lmbIsPressed == true)
// 		{
// 			cursorPosition = GetMousePosition();
// 			selectedObjectRotation = new Vector3(cursorPosition.x, cursorPosition.y, 0.0f);
// 			yield return null;
// 		}
// 	}

// }
