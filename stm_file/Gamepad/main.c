/* Include core modules */
#include "stm32f4xx.h"
/* Include my libraries here */

#include "defines.h"
#include "tm/tm_stm32f4_usb_hid_device.h"
#include "tm/tm_stm32f4_delay.h"
#include "tm/tm_stm32f4_disco.h"
#include "stm32f4_discovery_lis302dl.h"

int acc_x, acc_y, acc_z, up=64, down=64, left=64, right=64, x, y;

void initAccelerometer()
{
	LIS302DL_InitTypeDef LIS302DL_InitStruct;
	LIS302DL_InitStruct.Power_Mode=LIS302DL_LOWPOWERMODE_ACTIVE;
	LIS302DL_InitStruct.Output_DataRate=LIS302DL_DATARATE_100;
	LIS302DL_InitStruct.Axes_Enable=LIS302DL_XYZ_ENABLE;
	LIS302DL_InitStruct.Full_Scale=LIS302DL_FULLSCALE_2_3;
	LIS302DL_InitStruct.Self_Test = LIS302DL_SELFTEST_NORMAL;
	LIS302DL_Init(&LIS302DL_InitStruct);
}

int main(void) {
	uint8_t already = 0;

	/* Set structs for all examples */
	TM_USB_HIDDEVICE_Keyboard_t Keyboard;
	TM_USB_HIDDEVICE_Gamepad_t Gamepad1, Gamepad2;
	TM_USB_HIDDEVICE_Mouse_t Mouse;

	/* Initialize system */
	SystemInit();

	/* Initialize leds */
	TM_DISCO_LedInit();
	TM_DISCO_LedOn(LED_ALL);
	/* Initialize button */
	TM_DISCO_ButtonInit();

	/* Initialize delay */
	TM_DELAY_Init();

	/* Initialize USB HID Device */
	TM_USB_HIDDEVICE_Init();

	/* Set default values for mouse struct */
	TM_USB_HIDDEVICE_MouseStructInit(&Mouse);
	/* Set default values for keyboard struct */
	TM_USB_HIDDEVICE_KeyboardStructInit(&Keyboard);
	/* Set default values for gamepad structs */
	TM_USB_HIDDEVICE_GamepadStructInit(&Gamepad1);
	TM_USB_HIDDEVICE_GamepadStructInit(&Gamepad2);

	initAccelerometer();

	while (1) {
		TM_DISCO_LedOn(LED_ALL);
		/* If we are connected and drivers are OK */

		if (TM_USB_HIDDEVICE_GetStatus() == TM_USB_HIDDEVICE_Status_Connected) {
			/* Turn on green LED */
			TM_DISCO_LedOn(LED_RED);

			LIS302DL_Read(&acc_x,LIS302DL_OUT_X_ADDR,1);
			LIS302DL_Read(&acc_y,LIS302DL_OUT_Y_ADDR,1);
			LIS302DL_Read(&acc_z,LIS302DL_OUT_Z_ADDR,1);

			if(acc_y < 250 && acc_y > 200){
			    down = (acc_y - 200) * 1.3;
			    down = down < 0 ? 0 : down;
				Gamepad1.LeftYAxis = down; /* Y axis */
			}
			else if(acc_y > 10 && acc_y < 60){
			    up = acc_y + 80;
				up = up > 127 ? 127 : up;
			    Gamepad1.LeftYAxis = up; /* Y axis */
			}
			if(acc_x > 200 && acc_x < 250){
				right = (320 - acc_x) * 1.27;
				right = right > 127 ? 127 : right;
				Gamepad1.LeftXAxis = right; /* X axis */
			}
			else if(acc_x > 10 && acc_x < 60){
				left = (50 -  acc_x) * 1.3;
				left = left < 0 ? 0 : left;
				Gamepad1.LeftXAxis = left; /* X axis */
			}
			if(acc_x < 10 && acc_y < 10){
				Gamepad1.LeftYAxis = 64; /* Y axis */
				Gamepad1.LeftXAxis = 64; /* X axis */
				right = 64;
				left = 64;
			}
			//Diagnostic variables
			x = Gamepad1.LeftXAxis;
			y = Gamepad1.LeftYAxis;

			TM_USB_HIDDEVICE_GamepadSend(TM_USB_HIDDEVICE_Gamepad_Number_1, &Gamepad1);
		}else {
			/* Turn off green LED */
			TM_DISCO_LedOff(LED_GREEN);
		}
	}
}
