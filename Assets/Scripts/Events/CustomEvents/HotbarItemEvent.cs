﻿using UnityEngine;
using DapperDino.Items;
namespace DapperDino.Events.CustomEvents
{
    [CreateAssetMenu(fileName = "New Hotbar Item Event", menuName = "Game Events/Hotbar Item Event")]
    public class HotbarItemEvent : BaseGameEvent<HotbarItem> { }
}
