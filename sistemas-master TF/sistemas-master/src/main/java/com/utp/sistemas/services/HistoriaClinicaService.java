package com.utp.sistemas.services;

import com.utp.sistemas.entities.HistoriaClinica;
import com.utp.sistemas.repositories.HistoriaClinicaRepository;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.stereotype.Service;

import java.util.List;
import java.util.Optional;

@Service
public class HistoriaClinicaService {

    @Autowired
    private HistoriaClinicaRepository historiaClinicaRepository;

    public HistoriaClinica createHistoriaClinica(HistoriaClinica historiaClinica) {
        return historiaClinicaRepository.save(historiaClinica);
    }

    public List<HistoriaClinica> getAllHistoriaClinicas() {
        return historiaClinicaRepository.findAll();
    }

    public Optional<HistoriaClinica> getHistoriaClinicaById(Integer id) {
        return historiaClinicaRepository.findById(id);
    }

    public HistoriaClinica updateHistoriaClinica(Integer id, HistoriaClinica historiaClinicaDetails) {
        Optional<HistoriaClinica> historiaClinica = historiaClinicaRepository.findById(id);
        if (historiaClinica.isPresent()) {
            HistoriaClinica updatedHistoriaClinica = historiaClinica.get();
            updatedHistoriaClinica.setPaciente(historiaClinicaDetails.getPaciente());
            updatedHistoriaClinica.setFechaApertura(historiaClinicaDetails.getFechaApertura());
            updatedHistoriaClinica.setEstado(historiaClinicaDetails.getEstado());
            return historiaClinicaRepository.save(updatedHistoriaClinica);
        }
        return null;
    }

    public void deleteHistoriaClinica(Integer id) {
        Optional<HistoriaClinica> historiaClinica = historiaClinicaRepository.findById(id);
        historiaClinica.ifPresent(h -> historiaClinicaRepository.delete(h));
    }
}