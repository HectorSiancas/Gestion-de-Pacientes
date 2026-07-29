package com.utp.sistemas.services;

import com.utp.sistemas.entities.DiaSemana;
import com.utp.sistemas.repositories.DiaSemanaRepository;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.stereotype.Service;

import java.util.List;
import java.util.Optional;

@Service
public class DiaSemanaService {

    @Autowired
    private DiaSemanaRepository diaSemanaRepository;

    public DiaSemana createDiaSemana(DiaSemana diaSemana) {
        return diaSemanaRepository.save(diaSemana);
    }

    public List<DiaSemana> getAllDiasSemana() {
        return diaSemanaRepository.findAll();
    }

    public Optional<DiaSemana> getDiaSemanaById(Integer id) {
        return diaSemanaRepository.findById(id);
    }

    public DiaSemana updateDiaSemana(Integer id, DiaSemana diaSemanaDetails) {
        Optional<DiaSemana> diaSemana = diaSemanaRepository.findById(id);
        if (diaSemana.isPresent()) {
            DiaSemana updatedDiaSemana = diaSemana.get();
            updatedDiaSemana.setNombreDiaSemana(diaSemanaDetails.getNombreDiaSemana());
            return diaSemanaRepository.save(updatedDiaSemana);
        }
        return null;
    }

    public void deleteDiaSemana(Integer id) {
        Optional<DiaSemana> diaSemana = diaSemanaRepository.findById(id);
        diaSemana.ifPresent(d -> diaSemanaRepository.delete(d));
    }
}