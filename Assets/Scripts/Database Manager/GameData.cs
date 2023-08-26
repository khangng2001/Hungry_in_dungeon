using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Position
{
    [BsonElement("x")]
    public float X { get; set; }
    [BsonElement("y")]
    public float Y { get; set; }
    [BsonElement("z")]
    public float Z { get; set; }
}

public class Item
{
    [BsonElement("name")]
    public float Name { get; set; }
    [BsonElement("count")]
    public float Count { get; set; }
    [BsonElement("slot")]
    public float Slot { get; set; }
}

public partial class GameData
{
    [BsonId]
    [BsonElement("_id")]
    public ObjectId Id { get; set; } = ObjectId.GenerateNewId();
    [BsonElement("pid")]
    public string Pid { get; set; }
    [BsonElement("name")]
    public string Name { get; set; }
    [BsonElement("scene")]
    public int Scene { get; set; }
    [BsonElement("position")]
    public Position Position { get; set; }
    [BsonElement("health")]
    public int Health { get; set; }
    [BsonElement("exp")]
    public float Exp { get; set; }
    [BsonElement("level")]
    public int Level { get; set; }
    [BsonElement("damage")]
    public float Damage { get; set; }
    [BsonElement("inventory")]
    public List<Item> Inventory { get; set; }
}
