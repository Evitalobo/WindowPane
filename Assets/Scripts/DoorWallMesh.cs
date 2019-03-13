 using UnityEngine;
 using System.Collections;
 
 public class DoorWallMesh : MonoBehaviour {    
	
	public Material material;
	public Vector3[] vertices = new Vector3[20] 
		{
			new Vector3(0,0,0), new Vector3(17,0,0), new Vector3(23.8f,0,0), new Vector3(68,0,0),
			new Vector3(68, -25, 0), new Vector3(23.8f, -25, 0), new Vector3(23.8f, -7, 0), new Vector3(17, -7, 0),
			new Vector3(17, -25, 0), new Vector3(0, -25, 0),
			new Vector3(0,0,1), new Vector3(17,0,1), new Vector3(23.8f,0,1), new Vector3(68,0,01),
			new Vector3(68, -25, 1), new Vector3(23.8f, -25, 1), new Vector3(23.8f, -7, 1), new Vector3(17, -7, 1),
			new Vector3(17, -25, 1), new Vector3(0, -25, 1)
		};
 
	public Vector2[] uvs = new Vector2[20];
	 

	public int[] triangles = new int[48]
		{
			0 ,8, 9, 0, 1, 8, 1, 6, 7, 1, 2, 6, 2, 4, 5, 2, 3, 4, 0, 9, 10, 10, 19, 19, 10, 19, 18, 10, 18, 11, 11,
			17, 16, 11, 16, 12, 12, 15, 14, 12, 14, 13, 3, 13, 4, 13, 14, 4
		};
     
     void Start () {
		 
		 for (int i = 0; i < uvs.Length; i++)
        {
            uvs[i] = new Vector2(vertices[i].x, vertices[i].z);
        }
		
		Mesh mesh = new Mesh(); 
		
         gameObject.AddComponent<MeshFilter>();
         gameObject.AddComponent<MeshRenderer>();
 
                 
 
         gameObject.GetComponent<MeshFilter>().mesh = mesh;
 
         mesh.name = "DoorWall";
 
         mesh.vertices = vertices;
         mesh.triangles = triangles;
         mesh.uv = uvs;
 
         mesh.RecalculateNormals ();
         ;
         transform.gameObject.GetComponent<Renderer>().material = material; //If you want a material.. you have it :)
 
     }
 }