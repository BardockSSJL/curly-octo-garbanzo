using System;
using System.Collections.Generic;
using UnityEngine;

namespace Pociones
{
    [CreateAssetMenu(menuName = "Pociones")]
    public class ListaPociones: ScriptableObject {
        [SerializeField] private PocionBase[] pociones;
        private Dictionary<string, PocionBase> idToPocion;

        private void Awake()
        {
            idToPocion = new Dictionary<string, PocionBase>();
            foreach (var pocion in pociones)
            {
                idToPocion.Add(pocion.Id, pocion);
            }
        }

        public PocionBase GetPocionPrefabById(string id)
        {
            if (!idToPocion.TryGetValue(id, out var pocion))
            {
                throw new Exception($"Hero with id {id} does not exit");
            }
            
            return pocion;
        }
    }
}
