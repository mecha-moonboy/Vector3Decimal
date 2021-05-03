# Vector3Decimal
Stores a 3D vector as decimal values.

Why?
A `float` can only store 7 digits of precision and `Vector3` uses `float`, limiting the precision of the vector at high magnitudes. To demonstrate:

If my minimum requirement for precision is 0.001 meters, then I can’t store numbers with values more than 7 decimal places away:

`NumA` is Valid: `6358.331` This number is precise to the 3rd decimal point, or in this case, it's precise to the tenth of a millimeter.

`NumB` is Invalid: `10223.99` This number is precise to the 2nd decimal point: not precise enough.

Notice that each of those numbers only contains 7 digits, the limit for a `float`. If you were to add just ~400 to the `NumA`, the decimal point would move one place to the left, making it invalid and only precise to the 2nd decimal point.

A `decimal` has 28-29 digits of precision. That’s a lot! To compare the precision of a `float` and a `decimal`, here’s some analogies.

A `float` can store distances of a few kilometers with precision to the millimeter.

A `decimal` can store distances of many SEXTILLIONS of kilometers, while maintaining precision to the millimeter.

`float`: `XXXX.XXX`

`decimal`: `XXX,XXX,XXX,XXX,XXX,XXX,XXX,XXX.XXX`

This amount of precision will allow me to simulate a unimaginably larger space.

Documentation


| First Header  | Second Header |
| ------------- | ------------- |
| Content Cell  | Content Cell  |
| Content Cell  | Content Cell  |


| ...                                               | ...                                                |
| ------------------------------------------------- | -------------------------------------------------- |
| `up`                                              | `new Vector3Decimal(0, 1, 0)`                      |
| `right`                                           | `new Vector3Decimal(1, 0, 0)`                      |
| `forward`                                         | `new Vector3Decimal(0, 0, 1)`                      |
| `zero`                                            | `new Vector3Decimal(0, 0, 0)`                      |
| `ToVector3f()`                                    | `Vector3` from `this`.                             |
| `Distance(Vector3Decimal a, Vector3Decimal b)`    | Distance from `a` to `b`.                          |
| `Dot()`                                           | Returns the dot product as a `decimal`.            |
| `Cross(Vector3Decimal a, Vector3Decimal b)`       | Cross product of `a` and `b` as a `Vector3Decimal` |
| `ToString()`                                      | String representation of `this`.                   |

This class is dependent on DecimalMath by nathanpjones.

I have made this struct nearly completely interchangeable with the `Vector3` type. Here’s an example:

```Beef
void UnloadBody(Body bod)
{
   Vector3Decimal pos = _obs_body._global_position + bod.transform.position; // position from reference frame position + difference
   
   bod._global_position = pos;
   
   Vector3Decimal vel =  _obs_body._global_velocity + bod.physics_properties.velocity; // velocity from reference frame position + difference
   
   bod._global_velocity = vel;
   
   _loaded_bodies.Remove(bod);
   
   bod.gameObject.SetActive(false);
   
}
```
This is an Unload() function I wrote for Stardeep. physics_properties.velocity and transform.postion are both Vector3s, but as you can see, I do arithmetic without needing to case the Vector3s.

