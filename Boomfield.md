# Boomfield battlefield 2 Mod
Boomfield tweaks the effectiveness of weapons, vehicles, and equipment to encourage a more methodical approach to gunfights and objectives.  
It also features other change aimed at either increasing realism or improving quality of life features.

## Changes
- Added more equipment to each kit.
- Increased weapon accuracy by reducing bullet deviations.
- Increased overall weapon damage.
- Increased overall scope zoom distance.
- Added tracer rounds to all weapons.
- Adjusted magazine counts.
- Increased dead body lifetime.
- Made vehicle wrecks stay longer.
- Limited ammo on stationary and vehicle-mounted weapons.

### Pending
- Added 32 and 64 player bot support to maps:
  - Dalian Plant
  - Daqing Oilfields
  - Dragon Valley
  - Fushe Pass
  - Gulf Of Oman
  - Kubra Dam
  - Mashtuur City
  - Operation Clean Sweep
  - Road To Jalalabad
  - Sharqi Peninsula
  - Songua Stalemate
  - Strike At Karkand
  - Wake Island 2007
  - Zatar Wetlands

### Proposed

- Make vehicles stronger and not destroy themselves.
- Add custom maps
  - Attack at Sea
  - Dogfighting
  - Shipment

## Modding Guide
How to change things:
1. Copy the object's files out of the `Objects_server.zip` folder in the base bf2 or xpack mod folder into the respective folder in your mod.
2. Set readonly to false on the copied files.
3. Edit the files.

## How to make Boomfield

### Soldiers

Set `ObjectTemplate.armor.TimeToStayAsWreck 216000` for all soldiers.
> This may affect performance with a full server. Test with as many players/bots as possible.

### Kits
Weapon indexes should be changed to accomodate the following kit loadouts:

| Class          | 1     | 2       | 3       | 4          | 5     | 6       | 7        | 8 | 9         |
|----------------|-------|---------|---------|------------|-------|---------|----------|---|-----------|
| *Spec. Forces* | Knife | Pistol+ | Carbine | Frag       | Flash | Medkit  | C4       | - | Parachute |
| *Sniper*       | Knife | Pistol+ | Sniper  | Frag       | Flash | Medkit  | Claymore | - | Parachute |
| *Assault*      | Knife | Pistol  | AR+     | Grenade L. | Smoke | Ammo    | -        | - | Parachute |
| *Support*      | Knife | Pistol  | LMG     | Frag       | Smoke | Ammo    | -        | - | Parachute |
| *Engineer*     | Knife | Pistol+ | Shotgun | Frag       | Smoke | AT Mine | Wrench   | - | Parachute |
| *Medic*        | Knife | Pistol  | AR      | Frag       | Smoke | Medkit  | Defib.   | - | Parachute |
| *Anti-Tank*    | Knife | Pistol  | SMG     | Rocket L.  | Smoke | AT Mine | -        | - | Parachute |

Where:

| Item         | CH                      | EU                       | MEC                    | US                       |
|--------------|-------------------------|--------------------------|------------------------|--------------------------|
| Knife        | kni_knife               | kni_knife                | kni_knife              | kni_knife                |
| Pistol       | chpis_qsz92             | USPIS_92FS               | RUPIS_Baghira          | USPIS_92FS               |
| Pistol+      | chpis_qsz92_silencer    | USPIS_92FS_silencer      | RUPIS_Baghira_silencer | USPIS_92FS_silencer      |
| Carbine      | chrif_type95            | eurif_hk53a3             | rurrif_ak74u           | USRIF_M4                 |
| SMG          | chrif_type85            | eurif_fnp90              | RURIF_Bizon            | USRIF_MP5_A3             |
| AR           | RURIF_AK47              | eurif_famas              | RURIF_AK101            | usrif_m16a2              |
| AR+          | RURIF_GP25              | gbrif_sa80a2_l85         | RURIF_GP30             | USRIF_M203               |
| LMG          | chlmg_type95            | eurif_hk21               | RULMG_RPK74            | USLMG_M249SAW            |
| Sniper       | chsni_type88            | gbrif_l96a1              | rurif_Dragunov         | USRIF_M24                |
| Shotgun      | chsht_Norinco982        | gbrif_benelli_m4         | RUSHT_saiga12          | usrif_remington11-87     |
| Grenade L.   | RURGL_GP25              | gbgr_sa80a2_l85          | RURGL_GP30             | USRGL_M203               |
| Rocket L.    | CHAT_ERYX               | CHAT_ERYX                | USATP_Predator         | USATP_Predator           |
| Frag         | USHGR_M67               | USHGR_M67                | USHGR_M67              | USHGR_M67                |
| Flash        | nshgr_flashbang         | nshgr_flashbang          | nshgr_flashbang        | nshgr_flashbang          |
| Smoke        | hgr_smoke               | hgr_smoke                | hgr_smoke              | hgr_smoke                |
| Claymore     | USMIN_Claymore          | USMIN_Claymore           | USMIN_Claymore         | USMIN_Claymore           |
| AT Mine      | at_mine                 | at_mine                  | at_mine                | at_mine                  |
| C4           | c4_explosives           | c4_explosives            | c4_explosives          | c4_explosives            |
| Wrench       | wrench                  | wrench                   | wrench                 | wrench                   |
| Defib.       | defibrillator           | defibrillator            | defibrillator          | defibrillator            |
| Ammo         | ammokit                 | ammokit                  | ammokit                | ammokit                  |
| Medkit       | medikit                 | medikit                  | medikit                | medikit                  |
| Parachute    | ParachuteLauncher       | ParachuteLauncher        | ParachuteLauncher      | ParachuteLauncher        |
| Artillery    | ars_d30                 | USART_LW155              | ars_d30                | USART_LW155              |
| S. Rocket L. | ats_hj8                 | ats_tow                  | ats_hj8                | ats_tow                  |
| S. SAM       | Igla_Djigit             | usaas_stinger            | Igla_Djigit            | usaas_stinger            |
| S. LMG       | chlmg_type95_stationary | uslmg_m249saw_stationary | rulmg_rpk74_stationary | uslmg_m249saw_stationary |
| S. HMG       | chhmg_type85            | HMG_M2HB / HMG_M134      | CHHMG_KORD             | HMG_M2HB / HMG_M134      |


### Weapons

#### Handheld Weapon Tweaks
The following tweaks should be applied to each weapon.

###### Damage
> Generally increase the overall weapon damage.

Set damage to:
- `ObjectTemplate.damage 30` for shotguns.
- `ObjectTemplate.damage 35` for pistols.
- `ObjectTemplate.damage 40` for SMGs.
- `ObjectTemplate.damage 50` for Carbines.
- `ObjectTemplate.damage 60` for ARs and LMGs.
- `ObjectTemplate.damage 90` for semi-auto snipers.
- `ObjectTemplate.damage 120` for bolt-action snipers.
- `ObjectTemplate.damage 200` for the USSNI_M95_Barret.

Set min damage to `ObjectTemplate.minDamage 10` for all weapons.

Set damage fall-off for shotguns to:
```
ObjectTemplate.distToStartLoseDamage 60
ObjectTemplate.distToMinDamage 200
```

###### Velocity
> Generally decrease the overall projectile velocity.

Set the velocities to:
- `ObjectTemplate.velocity 300` for shotguns.
- `ObjectTemplate.velocity 400` for pistols.
- `ObjectTemplate.velocity 500` for SMGs.
- `ObjectTemplate.velocity 600` for Carbines.
- `ObjectTemplate.velocity 700` for ARs and LMGs.
- `ObjectTemplate.velocity 800` for semi-auto Snipers.
- `ObjectTemplate.velocity 900` for bolt-action Snipers.
- `ObjectTemplate.velocity 1000` for the USSNI_M95_Barret.

###### Ammo
Set for 
```
rem ---BeginComp:DefaultAmmoComp ---
ObjectTemplate.createComponent DefaultAmmoComp
ObjectTemplate.ammo.nrOfMags 6
ObjectTemplate.ammo.magSize 30
ObjectTemplate.ammo.reloadTime 5
ObjectTemplate.ammo.autoReload 1
rem ---EndComp ---
```

Set the number of mags to:
- `ObjectTemplate.ammo.nrOfMags 4` for pistols.
- `ObjectTemplate.ammo.nrOfMags 6` for SMGs, Carbines, ARs, and Snipers.
- `ObjectTemplate.ammo.nrOfMags 2` for LMGs and Rocket Launchers.
- `ObjectTemplate.ammo.nrOfMags 5` for Grenade Launchers.

Stationary:
- `ObjectTemplate.ammo.nrOfMags 11` for aas_phalanx and S. Rocket L.s.

Set mag sizes to the realistic weapon magazine capacity.

###### Zoom
Set the add zoom factor to:
- `ObjectTemplate.zoom.addZoomFactor 0.6` for iron sights.
- `ObjectTemplate.zoom.addZoomFactor 0.3` for normal rifle scopes.
- `ObjectTemplate.zoom.addZoomFactor 0.1` for sniper scopes.
- `ObjectTemplate.zoom.addZoomFactor 0.05` for the M95 Barret.

Always set `ObjectTemplate.zoom.disableMuzzleWhenZoomed 0`.

###### Fire Rate
Both `ObjectTemplate.fire.roundsPerMinute` and `ObjectTemplate.fire.addFireRate` need to be set based on each specific weapon.

- `ObjectTemplate.fire.roundsPerMinute 600` is a safe middle ground for most full-auto weapons.

Where:
- `ObjectTemplate.fire.addFireRate 0` means semi-auto fire.
- `ObjectTemplate.fire.addFireRate 1` means burst fire.
- `ObjectTemplate.fire.addFireRate 2` means full-auto fire.

###### Deviation
> Generally decrease the overall deviation, thus increasing accuracy.

The base deviation component except for shotguns:
```
rem ---BeginComp:SoldierDeviationComp ---
ObjectTemplate.createComponent SoldierDeviationComp
ObjectTemplate.deviation.setFireDev 0.2 0.1 0.05
ObjectTemplate.deviation.minDev 0.1
ObjectTemplate.deviation.setTurnDev 0 0 0 0
ObjectTemplate.deviation.setSpeedDev 1 0.2 0.2 0.1
ObjectTemplate.deviation.setMiscDev 1 1 0.1
ObjectTemplate.deviation.devModStand 2
ObjectTemplate.deviation.devModCrouch 1.5
ObjectTemplate.deviation.devModLie 1
ObjectTemplate.deviation.devModZoom 0.8
rem ---EndComp ---
```

- `ObjectTemplate.deviation.setMiscDev 1.5 1.5 0.1` for pistols.
- `ObjectTemplate.deviation.setMiscDev 1.3 1.3 0.1` for SMGs.
- `ObjectTemplate.deviation.setMiscDev 1.1 1.1 0.1` for carbines.
- `ObjectTemplate.deviation.setMiscDev 1 1 0.1` for ARs and LMGs.
- `ObjectTemplate.deviation.setMiscDev 0.8 0.8 0.1` for snipers.

###### Tracers
The base tracer setup:
```
ObjectTemplate.tracerScaler 30
ObjectTemplate.maxTracerScaler 30
ObjectTemplate.minTracerScaler 1
ObjectTemplate.tracerSizeModifier 5
ObjectTemplate.tracerTemplate p_tracer_g
ObjectTemplate.tracerInterval 1
```

Set `ObjectTemplate.tracerInterval 0` for Pistols, Shotguns, and Snipers.
Set `ObjectTemplate.tracerInterval 1` for SMGs, Carbines, ARs, and LMGs.

Set `ObjectTemplate.tracerTemplate p_tracer_g` for all weapons except ?.
Set `ObjectTemplate.minTracerScaler 10` for Coaxial guns.

#### Missile Tweaks

Apply to the `at_predator` and `eryx`:

- `ObjectTemplate.damage 720`

### Vehicles

| Aircraft Type             | CH           | EU          | MEC       | US       |
|---------------------------|--------------|-------------|-----------|----------|
| Buggy Car                 |              |             |           |          |
| Transport Car             |              |             |           |          |
| Armored Personnel Carrier |              |             |           |          |
| Anti-Air Vehicle          |              |             |           |          |
| Tank                      |              |             |           |          |
| Attack Helicopter         | ahe_z10      | xpak2_tiger | ahe_havoc | ahe_ah1z |
| Transport Helicopter      |              |             |           |          |
| Scout Helicopter          |              |             |           |          |
| Fighter                   | air_j10      |             |           | air_f35b |
| Bomber                    | xpak2_fantan |             | air_su39  | air_a10  |

###### Armor

```
ObjectTemplate.armor.hpLostWhileUpSideDown 0
ObjectTemplate.armor.hpLostWhileInWater 0
ObjectTemplate.armor.hpLostWhileInDeepWater 50
...
ObjectTemplate.armor.wreckHitPoints 2500
ObjectTemplate.armor.timeToStayAsWreck 216000
```

Set `ObjectTemplate.armor.hpLostWhileUpSideDown 100` for all helicopters.

#### Attack Helicopters

###### Ammo

Set machine gun ammo component to:
```
rem ---BeginComp:DefaultAmmoComp ---
ObjectTemplate.createComponent DefaultAmmoComp
ObjectTemplate.ammo.nrOfMags 1
ObjectTemplate.ammo.magSize 1000
ObjectTemplate.ammo.reloadTime 8
ObjectTemplate.ammo.autoReload 1
ObjectTemplate.ammo.reloadWithoutPlayer 1
rem ---EndComp ---
```

Set `ObjectTemplate.ammo.magSize 500` for ahe_havoc.

Set rocket launcher ammo component to:
```
rem ---BeginComp:DefaultAmmoComp ---
ObjectTemplate.createComponent DefaultAmmoComp
ObjectTemplate.ammo.nrOfMags 1
ObjectTemplate.ammo.magSize 38
ObjectTemplate.ammo.reloadTime 8
ObjectTemplate.ammo.autoReload 1
ObjectTemplate.ammo.reloadWithoutPlayer 1
rem ---EndComp ---
```

Set flare ammo component to:
```
rem ---BeginComp:DefaultAmmoComp ---
ObjectTemplate.createComponent DefaultAmmoComp
ObjectTemplate.ammo.nrOfMags 5
ObjectTemplate.ammo.magSize 12
ObjectTemplate.ammo.minimumTimeUntilReload 5
ObjectTemplate.ammo.autoReload 1
ObjectTemplate.ammo.reloadWithoutPlayer 1
rem ---EndComp ---
```

###### Damage

Set machine gun damage to:
- `ObjectTemplate.damage 50` for ahe_ah1z and ahe_z10
- `ObjectTemplate.damage 150` for ahe_havoc
- `ObjectTemplate.damage 150` for xpak2_tiger

