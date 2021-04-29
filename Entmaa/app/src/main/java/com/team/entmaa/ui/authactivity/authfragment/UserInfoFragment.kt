package com.team.entmaa.ui.authactivity.authfragment

import android.app.DatePickerDialog
import android.os.Bundle
import android.util.Log
import androidx.fragment.app.Fragment
import android.view.LayoutInflater
import android.view.View
import android.view.ViewGroup
import android.widget.*
import androidx.fragment.app.FragmentManager
import com.google.android.material.datepicker.MaterialDatePicker
import com.google.android.material.textfield.TextInputLayout
import com.team.entmaa.R
import java.text.SimpleDateFormat
import java.util.*
import kotlin.collections.ArrayList

class UserInfoFragment : Fragment() {

    val arrayList:ArrayList<String> = ArrayList()

    override fun onCreateView(
        inflater: LayoutInflater, container: ViewGroup?,
        savedInstanceState: Bundle?
    ): View? {
        // Inflate the layout for this fragment
        val root =  inflater.inflate(R.layout.fragment_user_info, container, false)

                                            /****Menus***/
        val governorateMenu:TextInputLayout = root.findViewById(R.id.governorateMenu)
        val adapterGovernorateMenu = ArrayAdapter(requireContext(), R.layout.support_simple_spinner_dropdown_item, governorates)
        (governorateMenu.editText as? AutoCompleteTextView)?.setAdapter(adapterGovernorateMenu)

        val cityMenu:TextInputLayout = root.findViewById(R.id.cityMenu)
        val adapterCityMenu = ArrayAdapter(requireContext(), R.layout.support_simple_spinner_dropdown_item, cities)
        (cityMenu.editText as? AutoCompleteTextView)?.setAdapter(adapterCityMenu)

                                           /***DatePicker***/
        val calendar:Calendar = Calendar.getInstance()
        val dateOfBirth:EditText = root.findViewById(R.id.dateEditText)

        val datesetListener = object :DatePickerDialog.OnDateSetListener{
         override fun onDateSet(view: DatePicker?, year: Int, month: Int, dayOfMonth: Int) {
               calendar.set(Calendar.YEAR,year)
               calendar.set(Calendar.MONTH,month)
               calendar.set(Calendar.DAY_OF_MONTH,dayOfMonth)
               updateDate(calendar,dateOfBirth)
         }
        }
        dateOfBirth.setOnClickListener {
            Log.i("User","Clicked")
            context?.let { it1 ->
                DatePickerDialog(
                    it1,datesetListener,
                    calendar.get(Calendar.YEAR),
                    calendar.get(Calendar.MONTH),
                    calendar.get(Calendar.DAY_OF_MONTH)).show()
            }

        }

        return root
    }

    companion object{
        val governorates =
            listOf(
                "Alexandria","Aswan","Asyut","Beheira","Beni Suef","Cairo","Dakahlia","Damietta",
                "Faiyum","Gharbia","Giza","Ismailia","Kafr El Sheikh","Luxor","Matruh","Minya", "Monufia",
                "New Valley", "North Sinai", "Port Said", "Qalyubia", "Qena", "Red Sea", "Sharqia","Sohag",
                "South Sinai", "Suez"
            )

        val cities=
            listOf(
                "Cairo", "Alexandria", "Giza", "Shubra el-Khema", "Port Said", "Suez", "El Mahalla el Kubra",
                "El Mansoura", "Tanta","Asyut", "Fayoum", "Zagazig", "Ismailia", "Khusus", "Aswan", "Damanhur",
                "El-Minya", "Damietta", "Luxor", "Qena", "Beni Suef", "Sohag", "Shibin el-Kom", "Hurghada",
                "Banha", "Kafr al-Sheikh", "Mallawi", "El Arish", "Belbeis", "10th of Ramadan City", "Marsa Matruh",
                "Mit Ghamr", "Kafr el-Dawwar", "Qalyub", "Desouk", "Abu Kabir", "Girga", "Akhmim", "El-Matareya",
                "Edko", "Bilqas", "Zifta", "Samalut", "Menouf", "Senbellawein", "Tahta", "Bush", "Ashmoun", "Manfalut",
                "Senuris", "Beni Mazar", "Faqous", "Talkha", "Armant", "Maghagha", "Manzala", "Dairut", "Kom Ombo",
                "Kafr al-Zayat", "Abu Tig", "Qis", "Edfu", "Rosetta", "Esna", "Dikirnis", "Abnub", "Tima", "Beila",
                "El-Kanater al-Khiria", "Al-Fashn", "Al-Mansha", "Al-Kareen", "El-Gamalia", "Fuwa", "Minya al-Qamh",
                "Kharga", "Qus", "Khanka", "Abu Qirqas", "Biba", "Samannoud", "Minyet al-Nasr", "Shibin al-Qanater",
                "Ibshawai", "Sherbin", "Drib Nigm", "Basyoun", "Sers el-Lyan", "Dishna", "Al-Hamool", "Farshut", "Tala",
                "Ash-Shuhada", "Tamiya", "Mashtul el-Sook", "Sadat City", "El-Ghanayem", "Itsa", "Al-Baliyana", "Hosh Issa",
                "Matai", "Juhayna", "Sidi Salem", "Naj Hammadi", "Quesna", "Hehya", "Abul Matamir", "El Ubour", "El-Badari",
                "Al-Kanayat", "At-Tall al-Kabir", "El-Delengat", "Al-Hammam", "Tukh", "Bagour", "Etay el-Barud", "Deir Mawas",
                "Baltim", "Abu Hammad", "Abu Hummus", "Nabaroh", "Sharm el-Sheikh", "Daraw", "Al-Maragha", "Sumusta al-Waqf",
                "Al-Wasta", "Ihnasiya", "Kom Hamadah", "Al-Quseir", "Qallin", "Birkat al-Sab", "Safaga", "Ezbet el-Borg", "Faraskur",
                "Al-Ibrahimiya", "El-Santa", "Ras Gharib", "Sahel Selim", "Dar as-Salam", "Rafah", "Mit Salsil", "Al-Husseinieh", "Kafr el-Batikh",
                "Kafr Saqr", "Bani Ubayd", "El-Qantara", "Metoubes", "El-Rahmaniyah", "Shubrakhit", "El-Mahmoudiyah", "Al-Waqf", "New Damietta City",
                "Qaha", "Kotoor", "Abu Suweir-el-Mahatta", "Kafr Shukr", "Kafr Saad", "Qift", "Fayed", "Saqultah", "Wadi al-Natrun", "Naqadah", "As-Sarw",
                "Awlad Saqr", "Sidi Barrani", "Al-Basaliyah Bahri", "Badr", "Sedfa", "El-Qantara ash-Sharqiya", "Ar-Ruda", "Mut",
                "Al-Tur", "New Salhia", "Ash-Shaykh Zawid", "Riyadh", "New Beni Suef", "Aga", "Ad-Dabah", "Al-Zarqa", "As-Sibaiyah Gharb",
                "Siwa", "El-Idwa", "Yusuf as-Siddiq", "Al-Bayadiyah"

            )

    }


    private fun updateDate(calendar: Calendar,editText: EditText){
        val myformat = "dd/mm/yyyy"
        val sdf = SimpleDateFormat(myformat,Locale.UK)
        editText.setText(sdf.format(calendar.time).toString())
    }

}