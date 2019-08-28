using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Localizer : MonoBehaviour {

	public static Dictionary<string, string> GetDetails = new Dictionary<string, string>();

	private void Awake()
	{
		StartCoroutine(RequestAPI());
	}

	public IEnumerator RequestAPI()
	{
		WWWForm form = new WWWForm();
		form.AddField("token", "gsbuLw212zicplXyhNS3DUgCs19HcoFG");
        /// TEST IP ADDRESS
        // form.AddField("IP", "165.16.105.186");
        WWW www = new WWW("https://api.toolwareassets.com/v1/localizer/getlocation", form);
		yield return www;
		if (www.error == "" || www.error == null)
		{
			Debug.Log(www.text);
			string[] results = www.text.Split('#');
			GetDetails.Add("ip", results[0]);
			GetDetails.Add("delay", results[1]);
			GetDetails.Add("city", results[2]);
			GetDetails.Add("region", results[3]);
			GetDetails.Add("country_code", results[4]);
			GetDetails.Add("country_name", results[5]);
			GetDetails.Add("continent_code", results[6]);
			GetDetails.Add("continent_name", results[7]);
			GetDetails.Add("time_zone", results[8]);
			GetDetails.Add("currency_code", results[9]);
			GetDetails.Add("currency_symbol", results[10]);
			GetDetails.Add("currency_coverter", results[11]);
			GetDetails.Add("os", SystemInfo.operatingSystem.ToString());
			GetDetails.Add("device", SystemInfo.deviceType.ToString());
		}
		else
		{
			Debug.Log("Connection Error: " + www.error + " Details: " + www.text);
		}
	}
}
