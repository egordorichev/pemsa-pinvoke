using AOT;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PemsaInput : MonoBehaviour
{
    private static int PEMSA_BUTTON_COUNT = 7;
    private static int PEMSA_PLAYER_COUNT = 8;

    private static bool[,] buttonDown = new bool[PEMSA_BUTTON_COUNT, PEMSA_PLAYER_COUNT];
    private static bool[,] buttonPressed = new bool[PEMSA_BUTTON_COUNT, PEMSA_PLAYER_COUNT];

    private static float mouseX, mouseY;
    private static int mouseMask = 0;
    private static bool anyKeyDown = false;
    private static string lastKeyDown = "";

    // Used to translate rawImage rect transform coordinates to 0 - height instead of -height/2 - height/2
    private Vector2 rectTranslation;

    private PemsaController pemsaController;
    public EmulatorInput input;

    private void OnEnable()
    {
        input.Enable();
    }
    private void OnDisable()
    {
        input.Disable();
    }

    private void Awake()
    {
        pemsaController = GetComponent<PemsaController>();
        input = new EmulatorInput();

        input.PemsaControls.Left.performed += _ => buttonDown[0,0] = true;
        input.PemsaControls.Left.canceled += _ => buttonDown[0,0] = false;

        input.PemsaControls.Right.performed += _ => buttonDown[1, 0] = true;
        input.PemsaControls.Right.canceled += _ => buttonDown[1, 0] = false;

        input.PemsaControls.Up.performed += _ => buttonDown[2, 0] = true;
        input.PemsaControls.Up.canceled += _ => buttonDown[2, 0] = false;

        input.PemsaControls.Down.performed += _ => buttonDown[3, 0] = true;
        input.PemsaControls.Down.canceled += _ => buttonDown[3, 0] = false;

        input.PemsaControls.Z.performed += _ => buttonDown[4, 0] = true;
        input.PemsaControls.Z.canceled += _ => buttonDown[4, 0] = false;

        input.PemsaControls.X.performed += _ => buttonDown[5, 0] = true;
        input.PemsaControls.X.canceled += _ => buttonDown[5, 0] = false;


        //emulatorInput.Z.performed += _ => UpdateControls(6);
    }

    private void Update()
    {
        //
        // Update imput.
        //



        //buttonDown[0, 0] = input.GetEmulatorInput().Left.ReadValue<int>() > 0;
        //buttonDown[1, 0] = Input.GetKey(KeyCode.RightArrow);
        //buttonDown[2, 0] = Input.GetKey(KeyCode.UpArrow);
        //buttonDown[3, 0] = Input.GetKey(KeyCode.DownArrow);
        //buttonDown[4, 0] = input.GetEmulatorInput().Z.ReadValue<float>() > 0;
        //buttonDown[5, 0] = input.GetEmulatorInput().C.ReadValue<float>() > 0;
        //buttonDown[6, 0] = Input.GetKey(KeyCode.P);

        //buttonPressed[0, 0] = Input.GetKeyDown(KeyCode.LeftArrow);
        //buttonPressed[1, 0] = Input.GetKeyDown(KeyCode.RightArrow);
        //buttonPressed[2, 0] = Input.GetKeyDown(KeyCode.UpArrow);
        //buttonPressed[3, 0] = Input.GetKeyDown(KeyCode.DownArrow);
        //buttonPressed[4, 0] = Input.GetKeyDown(KeyCode.Z);
        //buttonPressed[5, 0] = Input.GetKeyDown(KeyCode.X);
        //buttonPressed[6, 0] = Input.GetKeyDown(KeyCode.P);

        //lock (lastKeyDown)
        //{
        //    lastKeyDown = Input.inputString;
        //}

        //anyKeyDown = Input.anyKeyDown;


        mouseMask = 0;
        //mouseMask |= Input.GetKey(KeyCode.Mouse0) ? 1 : 0;
        //mouseMask |= Input.GetKey(KeyCode.Mouse1) ? 2 : 0;
        //mouseMask |= Input.GetKey(KeyCode.Mouse2) ? 3 : 0;

        //Vector2 point;
        //RectTransform rectTransform = pemsaController.rawImage.GetComponent<RectTransform>();
        //RectTransformUtility.ScreenPointToLocalPointInRectangle(rectTransform, Input.mousePosition, Camera.main, out point);

        //mouseX = point.x;
        //mouseY = point.y;

        //rectTranslation = new Vector2(rectTransform.rect.width / 2, rectTransform.rect.height / 2);
        //mouseX += rectTranslation.x;
        //mouseY += rectTranslation.y;

        //mouseX = (mouseX / rectTransform.rect.width) * 128;
        //mouseY = (mouseY / rectTransform.rect.height) * 128;
    }

    void UpdateControls(int i)
    {
        buttonDown[i, 0] = !buttonDown[i, 0];
    }

    [MonoPInvokeCallback(typeof(PemsaLibrary.ManagedIsButtonDown))]
    public static bool IsButtonDown(int i, int p)
    {
        lock (buttonPressed)
        {
            return buttonDown[i, p];
        }
    }

    [MonoPInvokeCallback(typeof(PemsaLibrary.ManagedIsButtonPressed))]
    public static bool IsButtonPressed(int i, int p)
    {
        return buttonPressed[i, p]; 
    }

    [MonoPInvokeCallback(typeof(PemsaLibrary.ManagedUpdateInput))]
    public static void UpdateInput()
    {

    }

    [MonoPInvokeCallback(typeof(PemsaLibrary.ManagedGetMouseX))]
    public static int GetMouseX()
    {
        return (int)mouseX;
    }

    [MonoPInvokeCallback(typeof(PemsaLibrary.ManagedGetMouseY))]
    public static int GetMouseY()
    {
        return (int)mouseY;
    }

    [MonoPInvokeCallback(typeof(PemsaLibrary.ManagedGetMouseMask))]
    public static int GetMouseMask()
    {
        return mouseMask;
    }

    [MonoPInvokeCallback(typeof(PemsaLibrary.ManagedReadKey))]
    public static string ReadKey()
    {
        lock (lastKeyDown)
        {
            return lastKeyDown;
        }
    }

    [MonoPInvokeCallback(typeof(PemsaLibrary.ManagedHasKey))]
    public static bool HasKey()
    {
        return anyKeyDown;
    }

    [MonoPInvokeCallback(typeof(PemsaLibrary.ManagedResetInput))]
    public static void ResetInput()
    {
        for (int i = 0; i < PEMSA_BUTTON_COUNT; ++i)
        {
            for (int j = 0; j < PEMSA_PLAYER_COUNT; ++j)
            {
                buttonDown[i, j] = false;
            }
        }
    }

    [MonoPInvokeCallback(typeof(PemsaLibrary.ManagedGetClipboardText))]
    public static string GetClipboardText()
    {
        return GUIUtility.systemCopyBuffer;
    }
}
