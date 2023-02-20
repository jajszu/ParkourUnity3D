using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ViewManager : MonoBehaviour
{
    private static ViewManager instance;

    [SerializeField] private View startingView;
    [SerializeField] private View[] views;
    [SerializeField]
    private View currentView;
    private Stack<View> history = new Stack<View>();

    private void Awake()
    {
        if(instance == null) 
        {
            instance= this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public static T GetView<T>() where T : View
    {
        for (int i = 0; i < instance.views.Length; i++)
        {
            if (instance.views[i] is T tView)
            {
                return tView;
            }
        }
        return null;
    }

    public static void Show<T>(bool remember = true)
    {
        for (int i = 0; i < instance.views.Length; i++)
        {
            if (instance.views[i] is T)
            {
                if(instance.currentView != null)
                {
                    if (remember)
                    {
                        instance.history.Push(instance.currentView);
                    }
                    instance.currentView.Hide();
                }
                instance.views[i].Show();

                instance.currentView = instance.views[i];
            }
        }
    }

    public static void Show(View view,bool remember = true)
    {
        if (instance.currentView != null)
        {
            if (remember)
            {
                instance.history.Push(instance.currentView);
            }
            instance.currentView.Hide();
        }
        view.Show();
        Debug.Log("siema" + view);

        instance.currentView = view;
    }

    public static void GoBack()
    {
        if(instance.history.Count > 0)
        {
            Show(instance.history.Pop(),false);
        }
    }

    private void Start()
    {
        for (int i = 0; i < views.Length; i++)
        {
            views[i].Initialize();
            views[i].Hide();
        }
        if(startingView != null) 
        {
            Show(startingView,false);
        }
    }
}
