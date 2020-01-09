using System;
using UnityEngine.Events;
using DapperDino.Items;
namespace DapperDino.Events.UnityEvents
{
    [Serializable] public class UnityHotbarItemEvent : UnityEvent<HotbarItem> { }
}