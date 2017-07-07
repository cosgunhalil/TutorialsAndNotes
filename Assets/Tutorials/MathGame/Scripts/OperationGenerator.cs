using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OperationGenerator {

    public Operation GetOperation(int level = 0)
    {
        var operation = new Operation();

        operation.Numbers = GetNumbers(3);

        var numberList = new List<int>();
        foreach (var n in operation.Numbers)
        {
            numberList.Add(n);
        }

        int result = GetResult(numberList);

        operation.Result = result;

        return operation;
    }

    private List<int> GetNumbers(int numberCount)
    {
        List<int> numbers = new List<int>();
       
        for (int i = 0; i < numberCount; i++)
        {
            numbers.Add(UnityEngine.Random.Range(1, 10));
        }

        return numbers;
    }

	private int GetResult(List<int> numberList)
	{
        int result = 0;
        while (numberList.Count > 1)
        {
			int n1 = GetNumberFromTheList(numberList);
			int n2 = GetNumberFromTheList(numberList);

			result = Calculate(n1, n2);
            numberList.Add(result);
		}

        Debug.Log("RESULT = " + result);
        return result;
    }

    private int GetNumberFromTheList(List<int> numberList)
    {
        var index = UnityEngine.Random.Range(0, numberList.Count);
        var number = numberList[index];
        numberList.RemoveAt(index);

        return number;
    }

    private int Calculate(int v1, int v2)
    {
        var operationDecision = UnityEngine.Random.Range(0, 4);
        Debug.Log("Operation Decision = " + operationDecision);

        int result = 0;

        switch (operationDecision)
        {
            case (int)EOperation.addition:
                result = v1 + v2;
                Debug.Log("v1 = " + v1 + " + " + "v2 = " + v2 );
                break;
            case (int)EOperation.subtraction:
                result = v1 - v2;
                Debug.Log("v1 = " + v1 + " - " + "v2 = " + v2);
                break;
            case (int)EOperation.multiplication:
				result = v1 * v2;
                Debug.Log("v1 = " + v1 + " * " + "v2 = " + v2);
				break;
            case (int)EOperation.division:
                if (CheckDivideable(v1 , v2))
                {
					result = v1 / v2;
					Debug.Log("v1 = " + v1 + " / " + "v2 = " + v2);
                }
                else
                {
					result = v1 * v2;
					Debug.Log("v1 = " + v1 + " * " + "v2 = " + v2);
                }
                break;
            default:
                break;
        }

        return result;
    }

    private bool CheckDivideable(int v1, int v2)
    {
        var divideable = false;
        int divide = v1 / v2;
        if(v1 == divide * v2)
        {
            divideable = true;
        }

        return divideable;
    }
}

public enum EOperation
{
    addition,
    subtraction,
    multiplication,
    division
}
