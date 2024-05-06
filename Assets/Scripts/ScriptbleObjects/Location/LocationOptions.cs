using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu (fileName = "LocationOptions", menuName = "Location/NewFile")]
public class LocationOptions : ScriptableObject
{
   [SerializeField] private string _name;
   [SerializeField] private int _namberSector;
   [SerializeField] private int _classSector;
   [SerializeField] private int _costEffect;
   [SerializeField] private int _momentOfUsingEffect;
   [SerializeField] private int _effectSector;
}
