using UnityEngine.UI;
using UnityEngine.EventSystems;
using UnityEngine;

public class SpellButton : MonoBehaviour 
{
	public spellObjectHolder spellr;

	public Button spellButton;

	public Text spellText;

   public GameObject spellObject;

	public float timer;

	void Start()
	{
		preStuff ();
		spellr.spell.startSpellTiming = false;
		spellr.spell.reloading = false;
	}

	void Update()
	{
		if (spellr.spell.startSpellTiming == true)
		{
			spellButton.enabled = false;
		}
		else
		{
		//	spellButton.enabled = true;
		}
	
		preStuff();

	}

	public void preStuff()
	{
		spellr=GetComponentInChildren<spellObjectHolder>();
		spellr=GetComponentInChildren<spellObjectHolder>();
		spellButton = GetComponentInChildren<Button> ();
		spellText = GetComponentInChildren<Text> ();
		timer = spellr.spell.activeTime;
		spellText.text = spellr.spell.spellname;
		spellObject = spellr.spellObject;
		EventTrigger trigger = GetComponent<EventTrigger>( );
		EventTrigger.Entry entry = new EventTrigger.Entry( );
		entry.eventID = EventTriggerType.PointerEnter;
		entry.callback.AddListener( ( data ) => { OnPointerEnterDelegate( (PointerEventData)data ); } );
		if(trigger!=null)
		trigger.triggers.Add( entry );
		
	}
		

	public void Occupied()
	{
		 
		spellr.spell.startSpellTiming = false;
		spellr.spellObject.SetActive (false);

	}

	public void SpellTrigger()
	{
		spellButton.enabled =false;
		spellr.spell.startSpellTiming = true;
		spellr.spellObject.SetActive (true);
	}
		
	public void OnPointerEnterDelegate( PointerEventData data )
	{
		if (Input.GetButtonUp ("Fire2") && data.pointerCurrentRaycast.gameObject==spellButton) ;
		{
			SpellTrigger ();

		}

	}
}

