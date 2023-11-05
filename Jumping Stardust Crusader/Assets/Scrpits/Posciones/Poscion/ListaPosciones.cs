using System;
using System.Collections.Generic;
using UnityEngine;

namespace Posciones
{
    [CreateAssetMenu(menuName = "Posciones")]
    public class ListaPosciones: ScriptableObject {
        [SerializeField] private PoscionBase[] posciones;
        private Dictionary<string, PoscionBase> idToPoscion;

        private void Awake()
        {
            idToPoscion = new Dictionary<string, PoscionBase>();
            foreach (var poscion in posciones)
            {
                idToPoscion.Add(poscion.Id, poscion);
            }
        }

        public PoscionBase GetPoscionPrefabById(string id)
        {
            if (!idToPoscion.TryGetValue(id, out var poscion))
            {
                throw new Exception($"Hero with id {id} does not exit");
            }
            return poscion;
        }
    }
}
