 using UnityEngine;
 using System.Collections;
 
 public class KitchenDoorWallMesh : MonoBehaviour {    
	
	public Material material;
	public Vector3[] vertices = {
     new Vector3(-20.0f, 25.0f, 0.0f), new Vector3(20.0f, 25.0f, 0.0f), 
     new Vector3(20.0f, 0.0f, 0.0f), new Vector3(-20.0f, 0.0f, 0.0f),
     new Vector3(4.9f, 18.0f, 0.0f), new Vector3(13.1f, 18.0f, 0.0f), 
     new Vector3(13.1f, 0.0f, 0.0f), new Vector3(4.9f, 0.0f, 0.0f),
     new Vector3(4.9f, 18.0f, 0.0f), new Vector3(13.1f, 18.0f, 0.0f), 
     new Vector3(13.1f, 0.0f, 0.0f), new Vector3(4.9f, 0.0f, 0.0f),
     new Vector3(4.9f, 18.0f, 0.1f), new Vector3(13.1f, 18.0f, 0.1f), 
     new Vector3(13.1f, 0.0f, 0.1f), new Vector3(4.9f, 0.0f, 0.1f),
     new Vector3(4.9f, 18.0f, 0.1f), new Vector3(13.1f, 18.0f, 0.1f), 
     new Vector3(13.1f, 0.0f, 0.1f), new Vector3(4.9f, 0.0f, 0.1f)
 	};
 	public int[] triangles = {
     0,1,4, 1,5,4, 1,2,5, 2,6,5,
     3,0,7, 0,4,7, // <- two triangles less in the door mesh
     8,9,12, 9,13,12, 9,10,13, 10,14,13,
     10,11,14, 11,15,14, 11,8,15, 8,12,15
     //,16,17,19, 17,18,19 // <- these triangles close the door 
 	};

 	public Vector2[] uvs = new Vector2[20];

        
     void Start () {

     	 for (int i = 0; i < uvs.Length; i++)
         {
            uvs[i] = new Vector2((vertices[i].x + 20)/40, vertices[i].y/25);
         }   
		 
		 MeshFilter meshF = gameObject.AddComponent<MeshFilter>();
         MeshRenderer render = gameObject.AddComponent<MeshRenderer>();
         MeshCollider collider = gameObject.AddComponent<MeshCollider>();         
         render.material = material;
         Mesh mesh = new Mesh();
         mesh.vertices = vertices;
         mesh.triangles = triangles;
         mesh.uv = uvs; 
         collider.sharedMesh = mesh; 
         mesh.RecalculateNormals();
         meshF.mesh = mesh;
     }
 }