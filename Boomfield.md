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

### Pending

### Proposed
- Increase dead body lifetime.
- Limit ammo on stationary and vehicle-mounted weapons.
- Make vehicles stronger and not destroy themselves.
- Make vehicle wrecks stay longer.- Add custom maps
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

### Weapons

#### Weapon Categories
Definitions of weapon categories refered to in the following sections:

###### Pistol
- chpis_qsz92
- chpis_qsz92_silencer
- rupis_baghira
- rupis_baghira_silencer
- USPIS_92FS
- uspis_92fs_silencer
###### SMG
- CHRIF_Type85
- eurif_fnp90*
- RURIF_Bizon
- USRIF_MP5_A3
###### Carbine
- chrif_type95
- eurif_HK53A3
- rurrif_ak74u
- usrif_g36c*
- USRIF_M4
###### AR
- eurif_famas
- gbrif_sa80a2_l85
- RURIF_AK47
- RURIF_AK101
- RURIF_GP25
- RURIF_GP30
- usrif_fnscarl
- USRIF_G3A3*
- usrif_m16a2
- USRIF_M203
- usrif_sa80*
###### LMG
- chlmg_type95
- eurif_hk21
- RULMG_PKM*
- rulmg_rpk74
- USLMG_M249SAW
###### Sniper
- chsni_type88
- gbrif_l96a1
- rurif_dragunov
- usrif_m24
- USSNI_M95_Barret*
###### Shotgun
- chsht_norinco982
- chsht_protecta*
- gbrif_benelli_m4
- RUSHT_Saiga12
- usrif_remington11-87
- USSHT_Jackhammer
###### Grenade Launcher
- gbgr_sa80a2_l85
- RURGL_GP25
- RURGL_GP30
- USRGL_M203
###### Rocket Launcher
- CHAT_ERYX
- USATP_predator

### Weapon Tweaks
The following tweaks should be applied to each weapon.

#### Damage
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

#### Velocity
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

#### Ammo
Set the number of mags to:
- `ObjectTemplate.ammo.nrOfMags 4` for pistols.
- `ObjectTemplate.ammo.nrOfMags 6` for SMGs, Carbines, ARs, and Snipers.
- `ObjectTemplate.ammo.nrOfMags 2` for LMGs and Rocket Launchers.
- `ObjectTemplate.ammo.nrOfMags 5` for Grenade Launchers.

#### Zoom
Set the add zoom factor to:
- `ObjectTemplate.zoom.addZoomFactor 0.6` for iron sights.
- `ObjectTemplate.zoom.addZoomFactor 0.3` for normal rifle scopes.
- `ObjectTemplate.zoom.addZoomFactor 0.1` for sniper scopes.
- `ObjectTemplate.zoom.addZoomFactor 0.05` for the M95 Barret.

Always set `ObjectTemplate.zoom.disableMuzzleWhenZoomed 0`.

#### Fire Rate
Both `ObjectTemplate.fire.roundsPerMinute` and `ObjectTemplate.fire.addFireRate` need to be set based on each specific weapon.

- `ObjectTemplate.fire.roundsPerMinute 600` is a safe middle ground for most full-auto weapons.

Where:
- `ObjectTemplate.fire.addFireRate 0` means semi-auto fire.
- `ObjectTemplate.fire.addFireRate 1` means burst fire.
- `ObjectTemplate.fire.addFireRate 2` means full-auto fire.

#### Deviation
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

#### Tracers
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


