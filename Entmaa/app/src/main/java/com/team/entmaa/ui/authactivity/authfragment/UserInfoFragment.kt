package com.team.entmaa.ui.authactivity.authfragment

import android.app.Activity.RESULT_OK
import android.app.DatePickerDialog
import android.content.Intent
import android.os.Bundle
import android.util.Log
import android.view.LayoutInflater
import android.view.View
import android.view.ViewGroup
import android.widget.*
import androidx.fragment.app.Fragment
import com.google.android.material.imageview.ShapeableImageView
import com.google.android.material.textfield.TextInputLayout
import com.team.entmaa.R
import com.team.entmaa.ui.contributorprofileactivity.ProfileMainActivity
import java.io.InputStream
import java.text.SimpleDateFormat
import java.util.*


class UserInfoFragment : Fragment() {

    private val RESULT_LOAD_IMG = 1
   lateinit var profilePic:ShapeableImageView

    override fun onCreateView(
        inflater: LayoutInflater, container: ViewGroup?,
        savedInstanceState: Bundle?
    ): View? {
        // Inflate the layout for this fragment
        val root =  inflater.inflate(R.layout.fragment_user_info, container, false)

                                            /****Menus***/
        val governorateMenu:TextInputLayout = root.findViewById(R.id.governorateMenu)
        val adapterGovernorateMenu = ArrayAdapter(
            requireContext(),
            R.layout.support_simple_spinner_dropdown_item,
            governorates
        )
        (governorateMenu.editText as? AutoCompleteTextView)?.setAdapter(adapterGovernorateMenu)

        val cityMenu:TextInputLayout = root.findViewById(R.id.cityMenu)
        val adapterCityMenu = ArrayAdapter(
            requireContext(),
            R.layout.support_simple_spinner_dropdown_item,
            cities
        )
        (cityMenu.editText as? AutoCompleteTextView)?.setAdapter(adapterCityMenu)

                                           /***DatePicker***/
        val calendar:Calendar = Calendar.getInstance()
        val dateOfBirth:EditText = root.findViewById(R.id.dateEditText)

        val datesetListener = object :DatePickerDialog.OnDateSetListener{
         override fun onDateSet(view: DatePicker?, year: Int, month: Int, dayOfMonth: Int) {
               calendar.set(Calendar.YEAR, year)
               calendar.set(Calendar.MONTH, month)
               calendar.set(Calendar.DAY_OF_MONTH, dayOfMonth)
               updateDate(calendar, dateOfBirth)
         }
        }
        dateOfBirth.setOnClickListener {
            Log.i("User", "Clicked")
            context?.let { it1 ->
                DatePickerDialog(
                    it1, R.style.datepicker, datesetListener,
                    calendar.get(Calendar.YEAR),
                    calendar.get(Calendar.MONTH),
                    calendar.get(Calendar.DAY_OF_MONTH)
                ).show()
            }
        }

                    /***Get Picture from internal storage***/
        profilePic = root.findViewById(R.id.profilePic)

        profilePic.setOnClickListener {
            val photoPickerIntent = Intent(Intent.ACTION_PICK)
            photoPickerIntent.type = "image/*"
            photoPickerIntent.action = Intent.ACTION_OPEN_DOCUMENT
            photoPickerIntent.addCategory(Intent.CATEGORY_OPENABLE)
            startActivityForResult(Intent.createChooser(photoPickerIntent,"Hello"), RESULT_LOAD_IMG)

        }


        /***Redirect to Profile Activity***/
        val RegisterBut:Button = root.findViewById(R.id.butRegister)
        RegisterBut.setOnClickListener {
            val intent:Intent = Intent(activity,ProfileMainActivity::class.java)
            activity?.startActivity(intent)
        }

        return root
    }

    override  fun onActivityResult(reqCode: Int, resultCode: Int, data: Intent?) {
        val imageUri = data?.data ?: return

        if (resultCode == RESULT_OK) {
            val imageStream: InputStream? = imageUri?.let { activity?.contentResolver?.openInputStream(it) }
            profilePic.setImageURI(imageUri)
        }
    }



    /*fun getResizedBitmap(bm: Bitmap, newWidth: Int, newHeight: Int): Bitmap? {
        val width = bm.width
        val height = bm.height
        val scaleWidth = newWidth.toFloat() / width
        val scaleHeight = newHeight.toFloat() / height
        // CREATE A MATRIX FOR THE MANIPULATION
        val matrix = Matrix()
        // RESIZE THE BIT MAP
        matrix.postScale(scaleWidth, scaleHeight)

        // "RECREATE" THE NEW BITMAP
        val resizedBitmap = Bitmap.createBitmap(
            bm, 0, 0, width, height, matrix, false
        )
        bm.recycle()
        return resizedBitmap
    }*/

    companion object{


        val governorates =
            listOf(
                "Alexandria",
                "Aswan",
                "Asyut",
                "Beheira",
                "Beni Suef",
                "Cairo",
                "Dakahlia",
                "Damietta",
                "Faiyum",
                "Gharbia",
                "Giza",
                "Ismailia",
                "Kafr El Sheikh",
                "Luxor",
                "Matruh",
                "Minya",
                "Monufia",
                "New Valley",
                "North Sinai",
                "Port Said",
                "Qalyubia",
                "Qena",
                "Red Sea",
                "Sharqia",
                "Sohag",
                "South Sinai",
                "Suez"
            )

        val cities=
            listOf(
                "Cairo",
                "Alexandria",
                "Giza",
                "Shubra el-Khema",
                "Port Said",
                "Suez",
                "El Mahalla el Kubra",
                "El Mansoura",
                "Tanta",
                "Asyut",
                "Fayoum",
                "Zagazig",
                "Ismailia",
                "Khusus",
                "Aswan",
                "Damanhur",
                "El-Minya",
                "Damietta",
                "Luxor",
                "Qena",
                "Beni Suef",
                "Sohag",
                "Shibin el-Kom",
                "Hurghada",
                "Banha",
                "Kafr al-Sheikh",
                "Mallawi",
                "El Arish",
                "Belbeis",
                "10th of Ramadan City",
                "Marsa Matruh",
                "Mit Ghamr",
                "Kafr el-Dawwar",
                "Qalyub",
                "Desouk",
                "Abu Kabir",
                "Girga",
                "Akhmim",
                "El-Matareya",
                "Edko",
                "Bilqas",
                "Zifta",
                "Samalut",
                "Menouf",
                "Senbellawein",
                "Tahta",
                "Bush",
                "Ashmoun",
                "Manfalut",
                "Senuris",
                "Beni Mazar",
                "Faqous",
                "Talkha",
                "Armant",
                "Maghagha",
                "Manzala",
                "Dairut",
                "Kom Ombo",
                "Kafr al-Zayat",
                "Abu Tig",
                "Qis",
                "Edfu",
                "Rosetta",
                "Esna",
                "Dikirnis",
                "Abnub",
                "Tima",
                "Beila",
                "El-Kanater al-Khiria",
                "Al-Fashn",
                "Al-Mansha",
                "Al-Kareen",
                "El-Gamalia",
                "Fuwa",
                "Minya al-Qamh",
                "Kharga",
                "Qus",
                "Khanka",
                "Abu Qirqas",
                "Biba",
                "Samannoud",
                "Minyet al-Nasr",
                "Shibin al-Qanater",
                "Ibshawai",
                "Sherbin",
                "Drib Nigm",
                "Basyoun",
                "Sers el-Lyan",
                "Dishna",
                "Al-Hamool",
                "Farshut",
                "Tala",
                "Ash-Shuhada",
                "Tamiya",
                "Mashtul el-Sook",
                "Sadat City",
                "El-Ghanayem",
                "Itsa",
                "Al-Baliyana",
                "Hosh Issa",
                "Matai",
                "Juhayna",
                "Sidi Salem",
                "Naj Hammadi",
                "Quesna",
                "Hehya",
                "Abul Matamir",
                "El Ubour",
                "El-Badari",
                "Al-Kanayat",
                "At-Tall al-Kabir",
                "El-Delengat",
                "Al-Hammam",
                "Tukh",
                "Bagour",
                "Etay el-Barud",
                "Deir Mawas",
                "Baltim",
                "Abu Hammad",
                "Abu Hummus",
                "Nabaroh",
                "Sharm el-Sheikh",
                "Daraw",
                "Al-Maragha",
                "Sumusta al-Waqf",
                "Al-Wasta",
                "Ihnasiya",
                "Kom Hamadah",
                "Al-Quseir",
                "Qallin",
                "Birkat al-Sab",
                "Safaga",
                "Ezbet el-Borg",
                "Faraskur",
                "Al-Ibrahimiya",
                "El-Santa",
                "Ras Gharib",
                "Sahel Selim",
                "Dar as-Salam",
                "Rafah",
                "Mit Salsil",
                "Al-Husseinieh",
                "Kafr el-Batikh",
                "Kafr Saqr",
                "Bani Ubayd",
                "El-Qantara",
                "Metoubes",
                "El-Rahmaniyah",
                "Shubrakhit",
                "El-Mahmoudiyah",
                "Al-Waqf",
                "New Damietta City",
                "Qaha",
                "Kotoor",
                "Abu Suweir-el-Mahatta",
                "Kafr Shukr",
                "Kafr Saad",
                "Qift",
                "Fayed",
                "Saqultah",
                "Wadi al-Natrun",
                "Naqadah",
                "As-Sarw",
                "Awlad Saqr",
                "Sidi Barrani",
                "Al-Basaliyah Bahri",
                "Badr",
                "Sedfa",
                "El-Qantara ash-Sharqiya",
                "Ar-Ruda",
                "Mut",
                "Al-Tur",
                "New Salhia",
                "Ash-Shaykh Zawid",
                "Riyadh",
                "New Beni Suef",
                "Aga",
                "Ad-Dabah",
                "Al-Zarqa",
                "As-Sibaiyah Gharb",
                "Siwa",
                "El-Idwa",
                "Yusuf as-Siddiq",
                "Al-Bayadiyah"

            )




    }



    private fun updateDate(calendar: Calendar, editText: EditText){
        val myformat = "dd/mm/yyyy"
        val sdf = SimpleDateFormat(myformat, Locale.UK)
        editText.setText(sdf.format(calendar.time).toString())
    }


}